using Doss.Core.Commands.ServiceProviders;
using Doss.Core.Domain.Plans;
using Doss.Core.Domain.ServiceProviders;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.ServiceProviders.Handlers;

public class CreateServiceProviderOnBoardCompletedCommandHandler : BaseCommandHandler<CreateServiceProviderOnBoardCompletedCommand, CreateServiceProviderOnBoardCompletedCommandValidator>
{
    private readonly IOnBoardServiceProviderRepository onBoardServiceProviderRepository;
    private readonly IServiceProviderRepository serviceProviderRepository;
    private readonly IBankRepository bankRepository;
    public CreateServiceProviderOnBoardCompletedCommandHandler(IServiceProviderRepository serviceProviderRepository,
                                                         IOnBoardServiceProviderRepository onBoardServiceProviderRepository,
                                                         IBankRepository bankRepository,
                                                         CreateServiceProviderOnBoardCompletedCommandValidator validator)
        : base(validator)
            => (this.serviceProviderRepository, this.onBoardServiceProviderRepository, this.bankRepository) = (serviceProviderRepository, onBoardServiceProviderRepository, bankRepository);

    public override async Task<Result> HandleImplementation(CreateServiceProviderOnBoardCompletedCommand command)
    {
        var onboard = await onBoardServiceProviderRepository.ReturnByIdAsync(command.UserId);

        if (onboard.IsNull())
            return Results.Ok("Onboard not found.");

        var serviceProvider = await serviceProviderRepository.ReturnByIdAsync(command.UserId);

        if (serviceProvider.IsNotNull())
            return Results.Error("service provider has already been registered.");

        serviceProvider = new ServiceProvider(command.UserId, onboard.OnBoardUser.Name, onboard.OnBoardUser.TypeDocument, onboard.OnBoardUser.Document, onboard.OnBoardUser.Phone, onboard.OnBoardUser.Photo, true);
        serviceProvider.AddVehicle(new Doss.Core.Domain.Vehicles.UserVehicle(onboard.Vehicle!));
        var bank = await bankRepository.ReturnByIdAsync(onboard.BankId!.Value);
        serviceProvider.AddServiceProviderPlan(new ServiceProviderPlan(onboard.AccountBank, onboard.AgencyBank, onboard.CoverageArea, onboard.Address!, bank, onboard.Plans!.Select(c => (Plan)c).ToList()!));
        serviceProvider.ChangeUserStatus(Doss.Core.Domain.Enums.UserStatus.Active);

        await serviceProviderRepository.AddAsync(serviceProvider);
        await serviceProviderRepository.SaveAsync();

        return Results.Ok("Service provider executed with success.");
    }
}

public sealed class CreateServiceProviderOnBoardCompletedCommandValidator : AbstractValidator<CreateServiceProviderOnBoardCompletedCommand>
{
    public CreateServiceProviderOnBoardCompletedCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
    }
}