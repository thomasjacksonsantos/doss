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

        var vehicle = new Vehicle(command.ModelVehicleId,
                                  command.Color,
                                  command.Plate,
                                  command.Photo,
                                  command.DefaultVehicle);

        residentialWithServiceProvider.AddVehicle(new ResidentialVehicle(command.ResidentialWithServiceProviderId,
                                                    vehicle));


        await residentialRepository.SaveAsync();

        await blobStorage.SendImage(command.Photo, $"/vehicle/{vehicle.Id}");

        return Results.Ok("Vehicle created with success.");
    }
}

public sealed class CreateResidentialVehicleCommandValidator : AbstractValidator<CreateResidentialVehicleCommand>
{
    public CreateResidentialVehicleCommandValidator()
    {
        RuleFor(c => c.ModelVehicleId).NotEmpty();
        RuleFor(c => c.Color).NotEmpty();
        RuleFor(c => c.Plate).NotEmpty();
        RuleFor(c => c.Photo).NotEmpty();
        RuleFor(c => c.DefaultVehicle).NotEmpty();
    }
}