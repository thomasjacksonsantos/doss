using System.Linq;
using Doss.Core.Commands.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.Vehicles.Handlers
{
    public class UpdateServiceProviderVehicleCommandHandler : BaseCommandHandler<UpdateServiceProviderVehicleCommand, UpdateServiceProviderVehicleCommandValidator>
    {
        private readonly IServiceProviderRepository serviceProviderRepository;
        public UpdateServiceProviderVehicleCommandHandler(IServiceProviderRepository serviceProviderRepository,
                                             UpdateServiceProviderVehicleCommandValidator validator)
            : base(validator)
                => this.serviceProviderRepository = serviceProviderRepository;

        public override async Task<Result> HandleImplementation(UpdateServiceProviderVehicleCommand command)
        {
            var serviceProvider = await serviceProviderRepository.ReturnVehiclesAll(command.User!.Id);

            if (serviceProvider.ServiceProviderVehicles!.Any(c => c.Vehicle.Id == command.Id) is false)
                return Results.Error("Vehicle not found");

            var vehicle = serviceProvider.ReturnVehicleById(command.Id);
            
            if (command.DefaultVehicle)
                serviceProvider.ResetDefaultVehicles();

            vehicle.ChangeBrand(command.Brand);
            vehicle.ChangeModel(command.Model);
            vehicle.ChangeColor(command.Color);
            vehicle.ChangePlate(command.Plate);
            vehicle.ChangePhoto(command.Photo);
            vehicle.ChangeDefaultVehicle(command.DefaultVehicle);
            vehicle.ChangeVehicleType(command.VehicleType);
            vehicle.ChangeDate(DateTime.Now);

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
}
