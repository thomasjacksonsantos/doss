using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;
public class UpdateBrandVehicleCommandHandler : BaseCommandHandler<UpdateBrandVehicleCommand, UpdateBrandVehicleCommandHandlerValidator>
{
    private readonly IBrandVehicleRepository brandVehicleRepository;
    public UpdateBrandVehicleCommandHandler(IBrandVehicleRepository brandVehicleRepository,
                                                  UpdateBrandVehicleCommandHandlerValidator validator)
        : base(validator)
            => (this.brandVehicleRepository) = (brandVehicleRepository);

    public override async Task<Result> HandleImplementation(UpdateBrandVehicleCommand command)
    {
        var brandVehicle = await brandVehicleRepository.ReturnByIdAsync(command.Id);
        brandVehicle.ChangeTypeVehicleId(command.TypeVehicleId);
        brandVehicle.ChangeDescription(command.Description);
        await brandVehicleRepository.SaveAsync();
        
        return Results.Ok("Type vehicle updated with success.");
    }
}

public sealed class UpdateBrandVehicleCommandHandlerValidator : AbstractValidator<UpdateBrandVehicleCommand>
{
    public UpdateBrandVehicleCommandHandlerValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TypeVehicleId).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}