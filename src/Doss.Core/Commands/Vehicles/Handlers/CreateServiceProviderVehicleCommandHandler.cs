using Doss.Core.Commands.Vehicles;
using Doss.Core.Domain.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.Vehicles.Handlers
{
    public class CreateServiceProviderVehicleCommandHandler : BaseCommandHandler<CreateServiceProviderVehicleCommand, CreateServiceProviderVehicleCommandValidator>
    {
        private readonly IServiceProviderVehicleRepository serviceProviderVehicleRepository;
        public CreateServiceProviderVehicleCommandHandler(IServiceProviderVehicleRepository serviceProviderVehicleRepository,
                                             CreateServiceProviderVehicleCommandValidator validator)
            : base(validator)
                => this.serviceProviderVehicleRepository = serviceProviderVehicleRepository;

        public override async Task<Result> HandleImplementation(CreateServiceProviderVehicleCommand command)
        {
            await serviceProviderVehicleRepository.AddAsync(new ServiceProviderVehicle(new Vehicle(command.Brand,
                                                                        command.Model,
                                                                        command.Color,
                                                                        command.Plate,
                                                                        command.Photo,
                                                                        command.DefaultVehicle,
                                                                        command.VehicleType)));

            await serviceProviderVehicleRepository.SaveAsync();

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
}
