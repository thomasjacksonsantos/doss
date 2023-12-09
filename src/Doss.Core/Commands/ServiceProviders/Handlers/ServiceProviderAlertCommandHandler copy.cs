using Doss.Core.Commands.ServiceProviders;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.ServiceProviders.Handlers;

public class UpdateServiceProviderStatusCommandHandler : BaseCommandHandler<UpdateServiceProviderStatusCommand, UpdateServiceProviderStatusCommandValidator>
{
    private readonly IServiceProviderRepository serviceProviderRepository;
    public UpdateServiceProviderStatusCommandHandler(IServiceProviderRepository serviceProviderRepository,
                                                UpdateServiceProviderStatusCommandValidator validator)
        : base(validator)
            => (this.serviceProviderRepository) = (serviceProviderRepository);

    public override async Task<Result> HandleImplementation(UpdateServiceProviderStatusCommand command)
    {
        await serviceProviderRepository.UpdateServiceProviderStatus(command.User!.Id, command.UserStatus);

        return Results.Ok("Status updated with success.");
    }
}

public sealed class UpdateServiceProviderStatusCommandValidator : AbstractValidator<UpdateServiceProviderStatusCommand>
{
    public UpdateServiceProviderStatusCommandValidator()
    {
        RuleFor(c => c.UserStatus).NotEmpty();
    }
}