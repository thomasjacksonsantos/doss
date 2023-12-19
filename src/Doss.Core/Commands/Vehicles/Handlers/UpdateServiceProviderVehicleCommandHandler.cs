using Doss.Core.Commands.Vehicles;
using Doss.Core.Domain.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.Vehicles.Handlers
{
    public class UpdateServiceProviderVehicleCommandHandler : BaseCommandHandler<UpdateServiceProviderVehicleCommand, UpdateServiceProviderVehicleCommandValidator>
    {
        private readonly IServiceProviderVehicleRepository serviceProviderVehicleRepository;
        public UpdateServiceProviderVehicleCommandHandler(IServiceProviderVehicleRepository serviceProviderVehicleRepository,
                                             UpdateServiceProviderVehicleCommandValidator validator)
            : base(validator)
                => this.serviceProviderVehicleRepository = serviceProviderVehicleRepository;

        public override async Task<Result> HandleImplementation(UpdateServiceProviderVehicleCommand command)
        {
            // await vehicleRepository.UpdateAsync(new ServiceProviderVehicle(new Vehicle(command.Id,
            //                                                                 command.Brand,
            //                                                                 command.Model,
            //                                                                 command.Color,
            //                                                                 command.Plate,
            //                                                                 command.Photo,
            //                                                                 command.DefaultVehicle,
            //                                                                 command.VehicleType)));

            await serviceProviderVehicleRepository.SaveAsync();

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
