using Doss.Core.Commands.Vehicles;
using Doss.Core.Domain.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.Vehicles.Handlers
{
    public class UpdateVehicleCommandHandler : BaseCommandHandler<UpdateVehicleCommand, UpdateVehicleCommandValidator>
    {
        private readonly IVehicleRepository vehicleRepository;
        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository,
                                             UpdateVehicleCommandValidator validator)
            : base(validator)
                => this.vehicleRepository = vehicleRepository;

        public override async Task<Result> HandleImplementation(UpdateVehicleCommand command)
        {
            await vehicleRepository.UpdateAsync(new Vehicle(command.Id,
                                                       command.Brand, 
                                                       command.Model, 
                                                       command.Color, 
                                                       command.Plate, 
                                                       command.Photo, 
                                                       command.DefaultVehicle, 
                                                       command.VehicleType));

            await vehicleRepository.SaveAsync();

            return Results.Ok("Vehicle updated with success.");
        }
    }

    public sealed class UpdateVehicleCommandValidator : AbstractValidator<UpdateVehicleCommand>
    {
        public UpdateVehicleCommandValidator()
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
}
