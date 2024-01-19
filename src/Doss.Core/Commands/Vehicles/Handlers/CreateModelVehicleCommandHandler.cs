using Doss.Core.Domain.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;
public class CreateModelVehicleCommandHandler : BaseCommandHandler<CreateModelVehicleCommand, CreateModelVehicleCommandHandlerValidator>
{
    private readonly IModelVehicleRepository modelVehicleRepository;
    public CreateModelVehicleCommandHandler(IModelVehicleRepository modelVehicleRepository,
                                            CreateModelVehicleCommandHandlerValidator validator)
        : base(validator)
            => (this.modelVehicleRepository) = (modelVehicleRepository);

    public override async Task<Result> HandleImplementation(CreateModelVehicleCommand command)
    {
        await modelVehicleRepository.AddAsync(new ModelVehicle(command.BrandVehicleId, command.Description), saveChanges: true);

        return Results.Ok("Type vehicle created with success.");
    }
}

public sealed class CreateModelVehicleCommandHandlerValidator : AbstractValidator<CreateModelVehicleCommand>
{
    public CreateModelVehicleCommandHandlerValidator()
    {
        RuleFor(c => c.BrandVehicleId).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}