using Doss.Core.Commands.OnBoard.ServiceProviders;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.OnBoard.ServiceProviders.Handlers;

public class ServiceProviderOnBoardTermsAcceptCommandHandler : BaseCommandHandler<ServiceProviderOnBoardTermsAcceptCommand, ServiceProviderOnBoardTermsAcceptCommandValidator>
{
    private readonly IOnBoardServiceProviderRepository onBoardServiceProviderRepository;
    public ServiceProviderOnBoardTermsAcceptCommandHandler(IOnBoardServiceProviderRepository onBoardServiceProviderRepository,
                                                       ServiceProviderOnBoardTermsAcceptCommandValidator validator)
        : base(validator)
            => this.onBoardServiceProviderRepository = onBoardServiceProviderRepository;

    public override async Task<Result> HandleImplementation(ServiceProviderOnBoardTermsAcceptCommand command)
    {
        var serviceProviderOnBoard = await onBoardServiceProviderRepository.ReturnByUserIdAsync(command.User!.Id);
        if (serviceProviderOnBoard.IsNull())
            return Results.Error("OnBoard not found.");

        serviceProviderOnBoard.ChangeStep(OnBoardStepEnum.TermsAccept);

        serviceProviderOnBoard.ChangeTermsAccept(new OnBoardTermsAccept(command.TermsAccept, DateTime.Now));        

        await onBoardServiceProviderRepository.SaveAsync();

        return Results.Ok("OnBoard successfully processed.");
    }
}

public sealed class ServiceProviderOnBoardTermsAcceptCommandValidator : AbstractValidator<ServiceProviderOnBoardTermsAcceptCommand>
{
    public ServiceProviderOnBoardTermsAcceptCommandValidator()
        => RuleFor(c => c.TermsAccept).NotEmpty();
}