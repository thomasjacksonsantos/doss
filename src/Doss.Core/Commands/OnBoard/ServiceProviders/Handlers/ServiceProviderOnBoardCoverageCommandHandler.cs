using Doss.Core.Commands.OnBoard.ServiceProviders;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.OnBoard.ServiceProviders.Handlers;

public class ServiceProviderOnBoardCoverageCommandHandler : BaseCommandHandler<ServiceProviderOnBoardCoverageCommand, ServiceProviderOnBoardCoverageCommandValidator>
{
    private readonly IOnBoardServiceProviderRepository onBoardServiceProviderRepository;
    public ServiceProviderOnBoardCoverageCommandHandler(IOnBoardServiceProviderRepository onBoardServiceProviderRepository,
                                                       ServiceProviderOnBoardCoverageCommandValidator validator)
        : base(validator)
            => this.onBoardServiceProviderRepository = onBoardServiceProviderRepository;

    public override async Task<Result> HandleImplementation(ServiceProviderOnBoardCoverageCommand command)
    {
        var serviceProviderOnBoard = await onBoardServiceProviderRepository.ReturnByIdAsync(command.User!.Id);
        if (serviceProviderOnBoard.IsNull())
            return Results.Error("OnBoard not found.");

        serviceProviderOnBoard.ChangeStep(OnBoardStepEnum.CoverageArea);
        serviceProviderOnBoard.ChangeCoverageArea(command.CoverageArea);

        await onBoardServiceProviderRepository.SaveAsync();
        return Results.Ok("OnBoard successfully processed.");
    }
}

public sealed class ServiceProviderOnBoardCoverageCommandValidator : AbstractValidator<ServiceProviderOnBoardCoverageCommand>
{
    public ServiceProviderOnBoardCoverageCommandValidator()
    {
        RuleFor(c => c.CoverageArea).NotEmpty();
    }
}