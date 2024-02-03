using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Doss.Core.Services;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;

public class UpdatePhotoVehicleCommandHandler : BaseCommandHandler<UpdatePhotoVehicleCommand, UpdatePhotoVehicleCommandValidator>
{
    private readonly IVehicleRepository vehicleRepository;
    private readonly IBlobStorage blobStorage;

    public UpdatePhotoVehicleCommandHandler(IVehicleRepository vehicleRepository,
                                            IBlobStorage blobStorage,
                                            UpdatePhotoVehicleCommandValidator validator)
        : base(validator)
            => (this.vehicleRepository, this.blobStorage) = (vehicleRepository, blobStorage);

    public override async Task<Result> HandleImplementation(UpdatePhotoVehicleCommand command)
    {
        var vehicle = await vehicleRepository.ReturnVehicleById(command.Id);

        if (vehicle is not {})
            return Results.Error("Vehicle not found");

        await blobStorage.DeleteImage(vehicle.PhotoUrl);

        var url = $"vehicle/image/{Guid.NewGuid()}";
        
        vehicle.ChangePhotoUrl(url);
        
        await blobStorage.SendImage(command.Photo, url);
        
        return Results.Ok("Vehicle updated with success.");
    }
}

public sealed class UpdatePhotoVehicleCommandValidator : AbstractValidator<UpdatePhotoVehicleCommand>
{
    public UpdatePhotoVehicleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Photo).NotEmpty();
    }
}