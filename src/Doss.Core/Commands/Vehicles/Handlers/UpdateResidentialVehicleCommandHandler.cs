using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;

public class UpdateResidentialVehicleCommandHandler : BaseCommandHandler<UpdateResidentialVehicleCommand, UpdateResidentialVehicleCommandValidator>
{
    private readonly IResidentialRepository residentialRepository;
    public UpdateResidentialVehicleCommandHandler(IResidentialRepository residentialRepository,
                                         UpdateResidentialVehicleCommandValidator validator)
        : base(validator)
            => this.residentialRepository = residentialRepository;

    public override async Task<Result> HandleImplementation(UpdateResidentialVehicleCommand command)
    {
        var residential = await residentialRepository.ReturnVehicles(command.User!.Id, command.ResidentialWithServiceProviderId);
        var residentialWithService = residential.ReturnResidentialWithServiceProvider(command.ResidentialWithServiceProviderId);
        if (residentialWithService.ResidentialVehicles!.Any(c => c.Vehicle.Id == command.Id) is false)
            return Results.Error("Vehicle not found");

        var vehicle = residentialWithService.ReturnVehicleById(command.Id);

        if (vehicle.DefaultVehicle)
            residentialWithService.ResetDefaultVehicles();

        vehicle.ChangeModelVehicle(command.ModelVehicleId);
        vehicle.ChangeColor(command.Color);
        vehicle.ChangePlate(command.Plate);
        vehicle.ChangePhoto(command.Photo);
        vehicle.ChangeDefaultVehicle(command.DefaultVehicle);
        vehicle.ChangeDate(DateTime.Now);

        await residentialRepository.SaveAsync();

        return Results.Ok("Vehicle updated with success.");
    }
}

public sealed class UpdateResidentialVehicleCommandValidator : AbstractValidator<UpdateResidentialVehicleCommand>
{
    public UpdateResidentialVehicleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ModelVehicleId).NotEmpty();
        RuleFor(c => c.Color).NotEmpty();
        RuleFor(c => c.Plate).NotEmpty();
        RuleFor(c => c.Photo).NotEmpty();
        RuleFor(c => c.DefaultVehicle).NotEmpty();
        RuleFor(c => c.VehicleType).NotEmpty();
    }
}