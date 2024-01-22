using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;

public class UpdateStatusVehicleCommandHandler : BaseCommandHandler<UpdateStatusVehicleCommand, UpdateStatusVehicleCommandValidator>
{
    private readonly IVehicleRepository vehicleRepository;
    public UpdateStatusVehicleCommandHandler(IVehicleRepository vehicleRepository,
                                              UpdateStatusVehicleCommandValidator validator)
        : base(validator)
            => this.vehicleRepository = vehicleRepository;

    public override async Task<Result> HandleImplementation(UpdateStatusVehicleCommand command)
    {
        await vehicleRepository.UpdateStatusVehicle(command.VehicleId, command.VehicleStatus);
        return Results.Ok("Status vehicle updated with success.");
    }
}

public sealed class UpdateStatusVehicleCommandValidator : AbstractValidator<UpdateStatusVehicleCommand>
{
    public UpdateStatusVehicleCommandValidator()
    {
        RuleFor(c => c.VehicleId).NotEmpty();
        RuleFor(c => c.VehicleStatus).NotEmpty();
    }
}