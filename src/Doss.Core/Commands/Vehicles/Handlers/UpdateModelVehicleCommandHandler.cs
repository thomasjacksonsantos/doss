using Doss.Core.Domain.Vehicles;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Vehicles.Handlers;
public class UpdateModelVehicleCommandHandler : BaseCommandHandler<UpdateModelVehicleCommand, UpdateModelVehicleCommandHandlerValidator>
{
    private readonly IModelVehicleRepository modelVehicleRepository;
    public UpdateModelVehicleCommandHandler(IModelVehicleRepository modelVehicleRepository,
                                            UpdateModelVehicleCommandHandlerValidator validator)
        : base(validator)
            => (this.modelVehicleRepository) = (modelVehicleRepository);

    public override async Task<Result> HandleImplementation(UpdateModelVehicleCommand command)
    {
        var modelVehicle = await modelVehicleRepository.ReturnByIdAsync(command.Id);
        modelVehicle.ChangeDescription(command.Description);
        modelVehicle.ChangeBrandVehicleId(command.BrandVehicleId);
        await modelVehicleRepository.SaveAsync();
        return Results.Ok("Type vehicle updated with success.");
    }
}

public sealed class UpdateModelVehicleCommandHandlerValidator : AbstractValidator<UpdateModelVehicleCommand>
{
    public UpdateModelVehicleCommandHandlerValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BrandVehicleId).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}