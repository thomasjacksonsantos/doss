using Doss.Core.Domain.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;
public class CreateBrandVehicleCommandHandler : BaseCommandHandler<CreateBrandVehicleCommand, CreateBrandVehicleCommandHandlerValidator>
{
    private readonly IBrandVehicleRepository brandVehicleRepository;
    public CreateBrandVehicleCommandHandler(IBrandVehicleRepository brandVehicleRepository,
                                                  CreateBrandVehicleCommandHandlerValidator validator)
        : base(validator)
            => (this.brandVehicleRepository) = (brandVehicleRepository);

    public override async Task<Result> HandleImplementation(CreateBrandVehicleCommand command)
    {
        await brandVehicleRepository.AddAsync(new BrandVehicle(command.TypeVehicleId, command.Description), saveChanges: true);

        return Results.Ok("Type vehicle created with success.");
    }
}

public sealed class CreateBrandVehicleCommandHandlerValidator : AbstractValidator<CreateBrandVehicleCommand>
{
    public CreateBrandVehicleCommandHandlerValidator()
    {
        RuleFor(c => c.TypeVehicleId).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}