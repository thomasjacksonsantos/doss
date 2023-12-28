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

        residentialWithServiceProvider.AddVehicle(new ResidentialVehicle(command.ResidentialWithServiceProviderId, 
                                                    new Vehicle(command.Brand,
                                                                command.Model,
                                                                command.Color,
                                                                command.Plate,
                                                                command.Photo,
                                                                command.DefaultVehicle,
                                                                command.VehicleType)));


        await residentialRepository.SaveAsync();

        using(var ms = new MemoryStream(Convert.FromBase64String(command.Photo)))
        {
            await blobStorage.Upload(ms, $"{command.Model}");
        }

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