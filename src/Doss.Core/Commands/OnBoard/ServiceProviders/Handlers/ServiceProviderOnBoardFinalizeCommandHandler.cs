using Doss.Core.Commands.OnBoard.ServiceProviders;
using Doss.Core.Domain.Addresses;
using Doss.Core.Domain.Users;
using Doss.Core.Domain.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.OnBoard.ServiceProviders.Handlers;

public class ServiceProviderOnBoardFinalizeCommandHandler : BaseCommandHandler<ServiceProviderOnBoardFinalizeCommand, ServiceProviderOnBoardFinalizeCommandValidator>
{
    private readonly IOnBoardServiceProviderRepository onBoardServiceProviderRepository;
    private readonly IServiceProviderRepository serviceProviderRepository;
    public ServiceProviderOnBoardFinalizeCommandHandler(IOnBoardServiceProviderRepository onBoardServiceProviderRepository,
                                                        IServiceProviderRepository serviceProviderRepository,
                                                        ServiceProviderOnBoardFinalizeCommandValidator validator)
        : base(validator)
            => (this.onBoardServiceProviderRepository, this.serviceProviderRepository) = (onBoardServiceProviderRepository, serviceProviderRepository);

    public override async Task<Result> HandleImplementation(ServiceProviderOnBoardFinalizeCommand command)
    {
        var serviceProviderOnBoard = await onBoardServiceProviderRepository.ReturnByUserIdAsync(command.User!.Id);
        if (serviceProviderOnBoard.IsNull())
            return Results.Error("OnBoard not found.");

        var serviceProviderVerify = await serviceProviderRepository.ReturnByUserIdAsync(command.User.Id);
        if (serviceProviderVerify.IsNotNull())
            throw new ArgumentOutOfRangeException("Service provider already exists in our database.");

        var serviceProvider = new ServiceProvider(serviceProviderOnBoard.TokenUserId,
                                                  serviceProviderOnBoard.User.Name,
                                                  serviceProviderOnBoard.User.Document,
                                                  serviceProviderOnBoard.User.Phone,
                                                  serviceProviderOnBoard.User.Phone,
                                                  true);

        var serviceProviderPlan = new ServiceProviderPlan(serviceProviderOnBoard.AccountBank, serviceProviderOnBoard.AgencyBank, serviceProviderOnBoard.CoverageArea);

        serviceProviderPlan.AddBank(serviceProviderOnBoard.Bank!);

        serviceProviderPlan.AddPlans(serviceProviderOnBoard.Plans!.Select(c => new Doss.Core.Domain.Plans.Plan(c.Description, c.Price))
                                                                  .ToList());

        serviceProviderPlan.AddAddress(new Address(serviceProviderOnBoard.Address!.Country,
                                                   serviceProviderOnBoard.Address.State,
                                                   serviceProviderOnBoard.Address.City,
                                                   serviceProviderOnBoard.Address.Street,
                                                   serviceProviderOnBoard.Address.ZipCode,
                                                   serviceProviderOnBoard.Address.Latitude,
                                                   serviceProviderOnBoard.Address.Longitude));

        serviceProvider.AddServiceProviderPlan(serviceProviderPlan);

        serviceProvider.AddVehicle(new Vehicle(serviceProviderOnBoard.Vehicle!.Brand,
                                               serviceProviderOnBoard.Vehicle.Model,
                                               serviceProviderOnBoard.Vehicle.Color,
                                               serviceProviderOnBoard.Vehicle.Plate,
                                               serviceProviderOnBoard.Vehicle.Photo,
                                               serviceProviderOnBoard.Vehicle.DefaultVehicle,
                                               serviceProviderOnBoard.Vehicle.VehicleType));

        await serviceProviderRepository.AddAsync(serviceProvider, saveChanges: true);

        return Results.Ok("OnBoard successfully processed.");
    }
}

public sealed class ServiceProviderOnBoardFinalizeCommandValidator : AbstractValidator<ServiceProviderOnBoardFinalizeCommand>
{
    public ServiceProviderOnBoardFinalizeCommandValidator()
    {
    }
}