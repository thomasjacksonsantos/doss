using Doss.Core.Commands.ServiceProviders;
using Doss.Core.Domain.Users;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.ServiceProviders.Handlers;

public class UpsertServiceProviderCommandHandler : BaseCommandHandler<UpsertServiceProviderCommand, UpsertServiceProviderCommandValidator>
{
    private readonly IServiceProviderRepository serviceProviderRepository;
    public UpsertServiceProviderCommandHandler(IServiceProviderRepository serviceProviderRepository, UpsertServiceProviderCommandValidator validator)
        : base(validator)
            => this.serviceProviderRepository = serviceProviderRepository;

    public override async Task<Result> HandleImplementation(UpsertServiceProviderCommand command)
    {
        if (command.Id.HasValue is false)
        {
            await serviceProviderRepository.AddAsync(new ServiceProvider(command.User.Id, command.Name, command.Document, command.Phone, command.Photo, command.CompletedRegistration), saveChanges: true);
            return Results.Ok("Service provider created with success.");
        }

        var serviceProvider = await serviceProviderRepository.ReturnByIdAsync(command.Id.Value);

        if (serviceProvider.IsNull())
            return Results.Error("Service provider not found.");

        serviceProvider.CompleteRegistration(command.CompletedRegistration);
        serviceProvider.ChangeUserStatus(command.UserStatus);
        serviceProvider.ChangeName(command.Name);
        serviceProvider.ChangeDocument(command.Document);
        serviceProvider.ChangePhoto(command.Photo);
        serviceProvider.ChangePhone(command.Phone);

        await serviceProviderRepository.SaveAsync();

        return Results.Ok("Service provider executed with success.");
    }
}

public sealed class UpsertServiceProviderCommandValidator : AbstractValidator<UpsertServiceProviderCommand>
{
    public UpsertServiceProviderCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Document).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.CompletedRegistration).NotEmpty();
    }
}