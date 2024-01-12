using Doss.Core.Domain.Plans;
using Doss.Core.Domain.ServiceProviders;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Doss.Core.Services;
using FluentValidation;

namespace Doss.Core.Commands.ServiceProviders.Handlers;

public class CreateServiceProviderOnBoardCompletedCommandHandler : BaseCommandHandler<CreateServiceProviderOnBoardCompletedCommand, CreateServiceProviderOnBoardCompletedCommandValidator>
{
    private readonly IOnBoardServiceProviderRepository onBoardServiceProviderRepository;
    private readonly IServiceProviderRepository serviceProviderRepository;
    private readonly IBankRepository bankRepository;
    private readonly IBlobStorage blobStorage;

    public CreateServiceProviderOnBoardCompletedCommandHandler(IServiceProviderRepository serviceProviderRepository,
                                                         IOnBoardServiceProviderRepository onBoardServiceProviderRepository,
                                                         IBankRepository bankRepository,
                                                         IBlobStorage blobStorage,
                                                         CreateServiceProviderOnBoardCompletedCommandValidator validator)
        : base(validator)
            => (this.serviceProviderRepository, this.onBoardServiceProviderRepository, this.bankRepository, this.blobStorage) = (serviceProviderRepository, onBoardServiceProviderRepository, bankRepository, blobStorage);

    public override async Task<Result> HandleImplementation(CreateServiceProviderOnBoardCompletedCommand command)
    {
        var onboard = await onBoardServiceProviderRepository.ReturnByIdAsync(command.UserId);

        if (onboard.IsNull())
            return Results.Ok("Onboard not found.");

        var serviceProvider = await serviceProviderRepository.ReturnByIdAsync(command.UserId);

        if (serviceProvider.IsNotNull())
            return Results.Error("service provider has already been registered.");

        serviceProvider = new ServiceProvider(command.UserId, onboard.OnBoardUser.Name, onboard.OnBoardUser.TypeDocument, onboard.OnBoardUser.Document, onboard.OnBoardUser.Phone, onboard.OnBoardUser.Photo, true);
        serviceProvider.AddVehicle(new Doss.Core.Domain.Vehicles.ServiceProviderVehicle(onboard.Vehicle!));
        var bank = await bankRepository.ReturnByIdAsync(onboard.BankId!.Value);
        serviceProvider.AddServiceProviderPlan(new ServiceProviderPlan(onboard.AccountBank, onboard.AgencyBank, onboard.CoverageArea, onboard.Address!, bank, onboard.Plans!.Select(c => (Plan)c).ToList()!));
        serviceProvider.ChangeUserStatus(Doss.Core.Domain.Enums.UserStatus.Active);

        await serviceProviderRepository.AddAsync(serviceProvider);
        await serviceProviderRepository.SaveAsync();

        var url = $"service-provider/image/{serviceProvider.Id}";

        serviceProvider.ChangePhotoUrl(url);

        await blobStorage.SendImage(onboard.OnBoardUser.Photo, url);

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