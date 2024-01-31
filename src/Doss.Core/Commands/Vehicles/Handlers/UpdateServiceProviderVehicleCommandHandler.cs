using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Doss.Core.Services;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;

public class UpdateServiceProviderVehicleCommandHandler : BaseCommandHandler<UpdateServiceProviderVehicleCommand, UpdateServiceProviderVehicleCommandValidator>
{
    private readonly IVehicleRepository vehicleRepository;
    private readonly IBlobStorage blobStorage;

    public UpdateServiceProviderVehicleCommandHandler(IVehicleRepository vehicleRepository,
                                                      IBlobStorage blobStorage,
                                                      UpdateServiceProviderVehicleCommandValidator validator)
        : base(validator)
            => (this.vehicleRepository, this.blobStorage) = (vehicleRepository, blobStorage);

    public override async Task<Result> HandleImplementation(UpdateServiceProviderVehicleCommand command)
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
            var url = $"vehicle/image/{vehicle.Id}";
            // vehicle.ChangePhoto(command.Photo);
            vehicle.ChangePhotoUrl(url);
            await blobStorage.SendImage(command.Photo, url);
        }

        await vehicleRepository.SaveAsync();

        if (command.DefaultVehicle)
            await vehicleRepository.KeepDefaultVehicleUpdate(command.User!.Id, command.Id);

        return Results.Ok("Vehicle updated with success.");
    }
}

public sealed class UpdateServiceProviderVehicleCommandValidator : AbstractValidator<UpdateServiceProviderVehicleCommand>
{
    public UpdateServiceProviderVehicleCommandValidator()
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