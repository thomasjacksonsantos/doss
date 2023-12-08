using Doss.Core.Commands.ServiceProviders;
using Doss.Core.Domain.Plans;
using Doss.Core.Domain.Users;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.ServiceProviders.Handlers;

public class ServiceProviderOnBoardCompletedCommandHandler : BaseCommandHandler<ServiceProviderOnBoardCompletedCommand, ServiceProviderOnBoardCompletedCommandValidator>
{
    private readonly IOnBoardServiceProviderRepository onBoardServiceProviderRepository;
    private readonly IServiceProviderRepository serviceProviderRepository;
    public ServiceProviderOnBoardCompletedCommandHandler(IServiceProviderRepository serviceProviderRepository,
                                                         IOnBoardServiceProviderRepository onBoardServiceProviderRepository,
                                                         ServiceProviderOnBoardCompletedCommandValidator validator)
        : base(validator)
            => (this.serviceProviderRepository, this.onBoardServiceProviderRepository) = (serviceProviderRepository, onBoardServiceProviderRepository);

    public override async Task<Result> HandleImplementation(ServiceProviderOnBoardCompletedCommand command)
    {
        var onboard = await onBoardServiceProviderRepository.ReturnByUserIdAsync(command.UserId);

        if (onboard.IsNull())
            return Results.Ok("Onboard not found.");

        var serviceProvider = await serviceProviderRepository.ReturnByIdAsync(command.UserId);

        if (serviceProvider.IsNotNull())
            return Results.Error("service provider has already been registered.");

        serviceProvider = new ServiceProvider(command.UserId, onboard.User.Name, onboard.User.TypeDocument, onboard.User.Document, onboard.User.Phone, onboard.User.Phone, true);
        serviceProvider.AddVehicle(onboard.Vehicle!);
        serviceProvider.AddServiceProviderPlan(new ServiceProviderPlan(onboard.AccountBank, onboard.AgencyBank, onboard.CoverageArea, onboard.Address!, onboard.Plans!.Select(c => (Plan)c)!));
        serviceProvider.ChangeUserStatus(Doss.Core.Domain.Enums.UserStatus.Active);

        await serviceProviderRepository.SaveAsync();

        return Results.Ok("Service provider executed with success.");
    }
}

public sealed class ServiceProviderOnBoardCompletedCommandValidator : AbstractValidator<ServiceProviderOnBoardCompletedCommand>
{
    public ServiceProviderOnBoardCompletedCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
    }
}