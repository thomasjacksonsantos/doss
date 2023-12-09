using Doss.Core.Commands.ServiceProviders;
using Doss.Core.Domain.Plans;
using Doss.Core.Domain.ServiceProviders;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.ServiceProviders.Handlers;

public class ServiceProviderOnBoardCompletedCommandHandler : BaseCommandHandler<ServiceProviderOnBoardCompletedCommand, ServiceProviderOnBoardCompletedCommandValidator>
{
    private readonly IOnBoardServiceProviderRepository onBoardServiceProviderRepository;
    private readonly IServiceProviderRepository serviceProviderRepository;
    private readonly IBankRepository bankRepository;
    public ServiceProviderOnBoardCompletedCommandHandler(IServiceProviderRepository serviceProviderRepository,
                                                         IOnBoardServiceProviderRepository onBoardServiceProviderRepository,
                                                         IBankRepository bankRepository,
                                                         ServiceProviderOnBoardCompletedCommandValidator validator)
        : base(validator)
            => (this.serviceProviderRepository, this.onBoardServiceProviderRepository, this.bankRepository) = (serviceProviderRepository, onBoardServiceProviderRepository, bankRepository);

    public override async Task<Result> HandleImplementation(ServiceProviderOnBoardCompletedCommand command)
    {
        var onboard = await onBoardServiceProviderRepository.ReturnByUserIdAsync(command.UserId);

        if (onboard.IsNull())
            return Results.Ok("Onboard not found.");

        var serviceProvider = await serviceProviderRepository.ReturnByUserIdAsync(command.UserId);

        if (serviceProvider.IsNotNull())
            return Results.Error("service provider has already been registered.");

        serviceProvider = new ServiceProvider(command.UserId, onboard.User.Name, onboard.User.TypeDocument, onboard.User.Document, onboard.User.Phone, onboard.User.Photo, true);
        serviceProvider.AddVehicle(onboard.Vehicle!);
        var bank = await bankRepository.ReturnByIdAsync(onboard.BankId!.Value);
        serviceProvider.AddServiceProviderPlan(new ServiceProviderPlan(onboard.AccountBank, onboard.AgencyBank, onboard.CoverageArea, onboard.Address!, bank, onboard.Plans!.Select(c => (Plan)c).ToList()!));
        serviceProvider.ChangeUserStatus(Doss.Core.Domain.Enums.UserStatus.Active);

        await serviceProviderRepository.AddAsync(serviceProvider);
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