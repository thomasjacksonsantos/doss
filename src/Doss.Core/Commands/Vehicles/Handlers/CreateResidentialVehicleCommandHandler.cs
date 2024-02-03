using Doss.Core.Domain.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Doss.Core.Services;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;
public class CreateResidentialVehicleCommandHandler : BaseCommandHandler<CreateResidentialVehicleCommand, CreateResidentialVehicleCommandValidator>
{
    private readonly IResidentialRepository residentialRepository;
    private readonly IBlobStorage blobStorage;
    public CreateResidentialVehicleCommandHandler(IResidentialRepository residentialRepository,
                                                  IBlobStorage blobStorage,
                                                  CreateResidentialVehicleCommandValidator validator)
        : base(validator)
            => (this.residentialRepository, this.blobStorage) = (residentialRepository, blobStorage);

    public override async Task<Result> HandleImplementation(CreateResidentialVehicleCommand command)
    {
        var residential = await residentialRepository.ReturnVehicles(command.User!.Id, command.ResidentialWithServiceProviderId);

        var residentialWithServiceProvider = residential.ReturnResidentialWithServiceProvider(command.ResidentialWithServiceProviderId);

        var vehicle = new Vehicle(command.Brand.FirstCharToUpper(),
                                  command.Model.FirstCharToUpper(),
                                  command.Color.FirstCharToUpper(),
                                  command.Plate.ToUpper(),
                                  command.Photo,
                                  command.DefaultVehicle,
                                  command.VehicleType);

        residentialWithServiceProvider.AddVehicle(new ResidentialVehicle(command.ResidentialWithServiceProviderId,
                                                    vehicle));


        await residentialRepository.SaveAsync();
        
        var url = $"vehicle/image/{Guid.NewGuid()}";

        await blobStorage.SendImage(command.Photo, url);

        vehicle.ChangePhotoUrl(url);

        await residentialRepository.SaveAsync();

        return Results.Ok("Vehicle created with success.");
    }
}

public sealed class CreateResidentialVehicleCommandValidator : AbstractValidator<CreateResidentialVehicleCommand>
{
    public CreateResidentialVehicleCommandValidator()
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