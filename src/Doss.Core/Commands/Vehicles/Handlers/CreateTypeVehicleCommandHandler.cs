using Doss.Core.Domain.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;
public class CreateTypeVehicleCommandHandler : BaseCommandHandler<CreateTypeVehicleCommand, CreateTypeVehicleCommandHandlerValidator>
{
    private readonly ITypeVehicleRepository typeVehicleRepository;
    public CreateTypeVehicleCommandHandler(ITypeVehicleRepository typeVehicleRepository,
                                                  CreateTypeVehicleCommandHandlerValidator validator)
        : base(validator)
            => (this.typeVehicleRepository) = (typeVehicleRepository);

    public override async Task<Result> HandleImplementation(CreateTypeVehicleCommand command)
    {
        await typeVehicleRepository.AddAsync(new TypeVehicle(command.Description), saveChanges: true);

        return Results.Ok("Type vehicle created with success.");
    }
}

public sealed class CreateTypeVehicleCommandHandlerValidator : AbstractValidator<CreateTypeVehicleCommand>
{
    public CreateTypeVehicleCommandHandlerValidator()
    {
        RuleFor(c => c.Description).NotEmpty();
    }
}