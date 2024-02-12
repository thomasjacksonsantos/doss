using Doss.Core.Domain.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Doss.Core.Services;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;
public class CreateServiceProviderVehicleCommandHandler : BaseCommandHandler<CreateServiceProviderVehicleCommand, CreateServiceProviderVehicleCommandValidator>
{
    private readonly IServiceProviderRepository serviceProviderRepository;
    private readonly IBlobStorage blobStorage;

    public CreateServiceProviderVehicleCommandHandler(IServiceProviderRepository serviceProviderRepository,
                                                      IBlobStorage blobStorage,
                                                      CreateServiceProviderVehicleCommandValidator validator)
        : base(validator)
            => (this.serviceProviderRepository, this.blobStorage) = (serviceProviderRepository, blobStorage);

    public override async Task<Result> HandleImplementation(CreateServiceProviderVehicleCommand command)
    {
        var serviceProvider = await serviceProviderRepository.ReturnByIdAsync(command.User!.Id);

        var vehicle = new Vehicle(command.Brand.FirstCharToUpper(),
                                  command.Model.FirstCharToUpper(),
                                  command.Color.FirstCharToUpper(),
                                  command.Plate.ToUpper(),
                                  command.DefaultVehicle,
                                  command.VehicleType);

        serviceProvider.AddVehicle(new ServiceProviderVehicle(vehicle));

        await serviceProviderRepository.SaveAsync();

        var url = $"vehicle/image/{Guid.NewGuid()}";

        await blobStorage.SendImage(command.Photo, url);

        vehicle.ChangePhotoUrl(url);

        await serviceProviderRepository.SaveAsync();

        return Results.Ok("Vehicle created with success.");
    }
}

public sealed class CreateServiceProviderVehicleCommandValidator : AbstractValidator<CreateServiceProviderVehicleCommand>
{
    public CreateServiceProviderVehicleCommandValidator()
    {
        RuleFor(c => c.Brand).NotEmpty();
        RuleFor(c => c.Model).NotEmpty();
        RuleFor(c => c.Color).NotEmpty();
        RuleFor(c => c.Plate).NotEmpty();
        RuleFor(c => c.Photo).NotEmpty();
        RuleFor(c => c.DefaultVehicle).NotEmpty();
        RuleFor(c => c.VehicleType).NotEmpty();
    }
}