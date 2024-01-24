using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Doss.Core.Services;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;

public class UpdateResidentialVehicleCommandHandler : BaseCommandHandler<UpdateResidentialVehicleCommand, UpdateResidentialVehicleCommandValidator>
{
    private readonly IResidentialRepository residentialRepository;
    private readonly IBlobStorage blobStorage;

    public UpdateResidentialVehicleCommandHandler(IResidentialRepository residentialRepository,
                                                  IBlobStorage blobStorage,
                                                  UpdateResidentialVehicleCommandValidator validator)
        : base(validator)
            => (this.residentialRepository, this.blobStorage) = (residentialRepository, blobStorage);

    public override async Task<Result> HandleImplementation(UpdateResidentialVehicleCommand command)
    {
        var residential = await residentialRepository.ReturnVehicles(command.User!.Id, command.ResidentialWithServiceProviderId);
        var residentialWithService = residential.ReturnResidentialWithServiceProvider(command.ResidentialWithServiceProviderId);
        if (residentialWithService.ResidentialVehicles!.Any(c => c.Vehicle.Id == command.Id) is false)
            return Results.Error("Vehicle not found");

        var vehicle = residentialWithService.ReturnVehicleById(command.Id);

        if (vehicle.DefaultVehicle)
            residentialWithService.ResetDefaultVehicles();

        vehicle.ChangeBrand(command.Brand);
        vehicle.ChangeModel(command.Model);
        vehicle.ChangeColor(command.Color);
        vehicle.ChangePlate(command.Plate);
        vehicle.ChangeDefaultVehicle(command.DefaultVehicle);
        vehicle.ChangeVehicleType(command.VehicleType);
        vehicle.ChangeDate(DateTime.Now);

        if (command.Photo.IsNotNullOrEmpty())
        {
            var url = $"vehicle/image/{vehicle.Id}";
            vehicle.ChangePhoto(command.Photo);
            vehicle.ChangePhotoUrl(url);
            await blobStorage.SendImage(command.Photo, url);
        }

        await residentialRepository.SaveAsync();

        return Results.Ok("Vehicle updated with success.");
    }
}

public sealed class UpdateResidentialVehicleCommandValidator : AbstractValidator<UpdateResidentialVehicleCommand>
{
    public UpdateResidentialVehicleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Brand).NotEmpty();
        RuleFor(c => c.Model).NotEmpty();
        RuleFor(c => c.Color).NotEmpty();
        RuleFor(c => c.Plate).NotEmpty();
        RuleFor(c => c.Photo).NotEmpty();
        RuleFor(c => c.DefaultVehicle).NotEmpty();
        RuleFor(c => c.VehicleType).NotEmpty();
    }
}