using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;
public class UpdateTypeVehicleCommandHandler : BaseCommandHandler<UpdateTypeVehicleCommand, UpdateTypeVehicleCommandHandlerValidator>
{
    private readonly ITypeVehicleRepository typeVehicleRepository;
    public UpdateTypeVehicleCommandHandler(ITypeVehicleRepository typeVehicleRepository,
                                                  UpdateTypeVehicleCommandHandlerValidator validator)
        : base(validator)
            => (this.typeVehicleRepository) = (typeVehicleRepository);

    public override async Task<Result> HandleImplementation(UpdateTypeVehicleCommand command)
    {
        var typeVehicle = await typeVehicleRepository.ReturnByIdAsync(command.Id);
        typeVehicle.ChangeDescription(command.Description);
        await typeVehicleRepository.SaveAsync();
        return Results.Ok("Type vehicle updated with success.");
    }
}

public sealed class UpdateTypeVehicleCommandHandlerValidator : AbstractValidator<UpdateTypeVehicleCommand>
{
    public UpdateTypeVehicleCommandHandlerValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}