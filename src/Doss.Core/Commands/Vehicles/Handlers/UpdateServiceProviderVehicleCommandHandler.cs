using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Doss.Core.Services;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;

public class UpdateServiceProviderVehicleCommandHandler : BaseCommandHandler<UpdateServiceProviderVehicleCommand, UpdateServiceProviderVehicleCommandValidator>
{
    private readonly IServiceProviderRepository serviceProviderRepository;
    private readonly IBlobStorage blobStorage;

    public UpdateServiceProviderVehicleCommandHandler(IServiceProviderRepository serviceProviderRepository,
                                                      IBlobStorage blobStorage,
                                                      UpdateServiceProviderVehicleCommandValidator validator)
        : base(validator)
            => (this.serviceProviderRepository, this.blobStorage) = (serviceProviderRepository, blobStorage);

    public override async Task<Result> HandleImplementation(UpdateServiceProviderVehicleCommand command)
    {
        var serviceProvider = await serviceProviderRepository.ReturnVehicles(command.User!.Id);

        if (serviceProvider.ServiceProviderVehicles!.Any(c => c.Vehicle.Id == command.Id) is false)
            return Results.Error("Vehicle not found");

        var vehicle = serviceProvider.ReturnVehicleById(command.Id);

        if (command.DefaultVehicle)
            serviceProvider.ResetDefaultVehicles();

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
            vehicle.ChangePhoto(command.Photo);
            vehicle.ChangePhotoUrl(url);
            await blobStorage.SendImage(command.Photo, url);
        }

        await serviceProviderRepository.SaveAsync();

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