using Doss.Core.Commands.Vehicles;
using Doss.Core.Domain.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.Vehicles.Handlers
{
    public class CreateVehicleCommandHandler : BaseCommandHandler<CreateVehicleCommand, CreateVehicleCommandValidator>
    {
        private readonly IVehicleRepository vehicleRepository;
        public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository,
                                             CreateVehicleCommandValidator validator)
            : base(validator)
                => this.vehicleRepository = vehicleRepository;

        public override async Task<Result> HandleImplementation(CreateVehicleCommand command)
        {
            await vehicleRepository.AddAsync(new UserVehicle(new Vehicle(command.Brand,
                                                                        command.Model,
                                                                        command.Color,
                                                                        command.Plate,
                                                                        command.Photo,
                                                                        command.DefaultVehicle,
                                                                        command.VehicleType)));

            await vehicleRepository.SaveAsync();

            return Results.Ok("Vehicle created with success.");
        }
    }

    public sealed class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
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
}
