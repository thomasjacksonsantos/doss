using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.OnBoard.ServiceProviders.Handlers;

public class ServiceProviderOnBoardVehicleCommandHandler : BaseCommandHandler<ServiceProviderOnBoardVehicleCommand, ServiceProviderOnBoardVehicleCommandValidator>
{
    private readonly IOnBoardServiceProviderRepository onBoardServiceProviderRepository;
    public ServiceProviderOnBoardVehicleCommandHandler(IOnBoardServiceProviderRepository onBoardServiceProviderRepository,
                                                       ServiceProviderOnBoardVehicleCommandValidator validator)
        : base(validator)
            => this.onBoardServiceProviderRepository = onBoardServiceProviderRepository;

    public override async Task<Result> HandleImplementation(ServiceProviderOnBoardVehicleCommand command)
    {
        var serviceProviderOnBoard = await onBoardServiceProviderRepository.ReturnByIdAsync(command.User!.Id);
        if (serviceProviderOnBoard.IsNull())
            return Results.Error("OnBoard not found.");

        serviceProviderOnBoard.ChangeStep(OnBoardStepEnum.Vehicle);

        if (serviceProviderOnBoard.Vehicle is not { })
            serviceProviderOnBoard.AddVehicle(new OnBoardVehicle(command.ModelVehicleId, command.Color, command.Plate, command.Photo, command.DefaultVehicle));
        else
        {
            serviceProviderOnBoard.Vehicle.ChangeModelVehicle(command.ModelVehicleId);
            serviceProviderOnBoard.Vehicle.ChangeColor(command.Color);
            serviceProviderOnBoard.Vehicle.ChangePlate(command.Plate);
            serviceProviderOnBoard.Vehicle.ChangePhoto(command.Photo);
            serviceProviderOnBoard.Vehicle.ChangeDefaultVehicle(command.DefaultVehicle);
        }

        await onBoardServiceProviderRepository.SaveAsync();

        return Results.Ok("OnBoard successfully processed.");
    }
}

public sealed class ServiceProviderOnBoardVehicleCommandValidator : AbstractValidator<ServiceProviderOnBoardVehicleCommand>
{
    public ServiceProviderOnBoardVehicleCommandValidator()
    {
        RuleFor(c => c.ModelVehicleId).NotEmpty();
        RuleFor(c => c.Color).NotEmpty();
        RuleFor(c => c.Plate).NotEmpty();
        RuleFor(c => c.Photo).NotEmpty();
        RuleFor(c => c.DefaultVehicle).NotEmpty();
    }
}