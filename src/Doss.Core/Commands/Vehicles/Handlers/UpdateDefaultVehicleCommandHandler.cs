using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;

public class UpdateDefaultVehicleCommandHandler : BaseCommandHandler<UpdateDefaultVehicleCommand, UpdateDefaultVehicleCommandValidator>
{
    private readonly IVehicleRepository vehicleRepository;
    public UpdateDefaultVehicleCommandHandler(IVehicleRepository vehicleRepository,
                                              UpdateDefaultVehicleCommandValidator validator)
        : base(validator)
            => this.vehicleRepository = vehicleRepository;

    public override async Task<Result> HandleImplementation(UpdateDefaultVehicleCommand command)
    {
        await vehicleRepository.UpdateDefaultVehicle(command.User!.Id, command.VehicleId, command.DefaultVehicle);
        return Results.Ok("Default vehicle updated with success.");
    }
}

public sealed class UpdateDefaultVehicleCommandValidator : AbstractValidator<UpdateDefaultVehicleCommand>
{
    public UpdateDefaultVehicleCommandValidator()
    {
        RuleFor(c => c.VehicleId).NotEmpty();
    }
}