using Doss.Core.Commands.Vehicles;
using Doss.Core.Domain.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;
public class CreateServiceProviderVehicleCommandHandler : BaseCommandHandler<CreateServiceProviderVehicleCommand, CreateServiceProviderVehicleCommandValidator>
{
    private readonly IServiceProviderRepository serviceProviderRepository;
    public CreateServiceProviderVehicleCommandHandler(IServiceProviderRepository serviceProviderRepository,
                                                      CreateServiceProviderVehicleCommandValidator validator)
        : base(validator)
            => this.serviceProviderRepository = serviceProviderRepository;

    public override async Task<Result> HandleImplementation(CreateServiceProviderVehicleCommand command)
    {
        var serviceProvider = await serviceProviderRepository.ReturnByIdAsync(command.User!.Id);

                serviceProvider.AddVehicle(new ServiceProviderVehicle(new Vehicle(command.Brand,
                                                                          command.Model,
                                                                          command.Color,
                                                                          command.Plate,
                                                                          command.Photo,
                                                                          command.DefaultVehicle,
                                                                          command.VehicleType)));

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