using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Doss.Core.Services;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;

public class UpdateResidentialVehicleCommandHandler : BaseCommandHandler<UpdateResidentialVehicleCommand, UpdateResidentialVehicleCommandValidator>
{
    private readonly IVehicleRepository vehicleRepository;
    private readonly IBlobStorage blobStorage;

    public UpdateResidentialVehicleCommandHandler(IVehicleRepository vehicleRepository,
                                                  IBlobStorage blobStorage,
                                                  UpdateResidentialVehicleCommandValidator validator)
        : base(validator)
            => (this.vehicleRepository, this.blobStorage) = (vehicleRepository, blobStorage);

    public override async Task<Result> HandleImplementation(UpdateResidentialVehicleCommand command)
    {
        var vehicle = await vehicleRepository.ReturnVehicleById(command.Id);

        if (vehicle is not {})
            return Results.Error("Vehicle not found");

        vehicle.ChangeBrand(command.Brand.FirstCharToUpper());
        vehicle.ChangeModel(command.Model.FirstCharToUpper());
        vehicle.ChangeColor(command.Color.FirstCharToUpper());
        vehicle.ChangePlate(command.Plate.ToUpper());
        vehicle.ChangeDefaultVehicle(command.DefaultVehicle);
        vehicle.ChangeVehicleType(command.VehicleType);
        vehicle.ChangeDate(DateTime.Now);

        if (command.Photo.IsNotNullOrEmpty())
        {
            await blobStorage.DeleteImage(vehicle.PhotoUrl);
            var url = $"vehicle/image/{Guid.NewGuid()}";
            vehicle.ChangePhotoUrl(url);
            await blobStorage.SendImage(command.Photo, url);
        }

        await vehicleRepository.SaveAsync();

        if (command.DefaultVehicle)
            await vehicleRepository.KeepDefaultVehicleUpdate(command.User!.Id, command.Id);

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