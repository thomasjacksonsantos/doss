using Doss.Core.Commands.OnBoard.ServiceProviders;
using Doss.Core.Commands.ServiceProviders;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;
using MediatR;

namespace Ageu.Core.Commands.OnBoard.ServiceProviders.Handlers;

public class ServiceProviderOnBoardFormPaymentCommandHandler : BaseCommandHandler<ServiceProviderOnBoardFormPaymentCommand, ServiceProviderOnBoardFormPaymentCommandValidator>
{
    private readonly IOnBoardServiceProviderRepository onBoardServiceProviderRepository;
    private readonly IBankRepository bankRepository;
    private readonly IMediator mediator;

    public ServiceProviderOnBoardFormPaymentCommandHandler(IOnBoardServiceProviderRepository onBoardServiceProviderRepository,
                                                           IBankRepository bankRepository,
                                                           IMediator mediator,
                                                           ServiceProviderOnBoardFormPaymentCommandValidator validator)
        : base(validator)
            => (this.onBoardServiceProviderRepository, this.bankRepository, this.mediator) = (onBoardServiceProviderRepository, bankRepository, mediator);

    public override async Task<Result> HandleImplementation(ServiceProviderOnBoardFormPaymentCommand command)
    {
        var serviceProviderOnBoard = await onBoardServiceProviderRepository.ReturnByUserIdAsync(command.User!.Id);
        if (serviceProviderOnBoard.IsNull())
            return Results.Error("OnBoard not found.");

        serviceProviderOnBoard.ChangeStep(OnBoardStepEnum.SelectPlan);

        if (serviceProviderOnBoard.Plans.IsNotNull())
            serviceProviderOnBoard.RemovePlans();
        
        var bank = await bankRepository.ReturnByIdAsync(command.BankId);

        serviceProviderOnBoard.AddBank(bank);
        serviceProviderOnBoard.ChangeAccountBank(command.Account);
        serviceProviderOnBoard.ChangeAgencyBank(command.Agency);
        serviceProviderOnBoard.AddPlan(command.Plans.Select(c => new OnBoardPlan(c.Description, c.Price)).ToList());

        await onBoardServiceProviderRepository.SaveAsync();

        /// TODO: Criar evento para salvar o usuario no dominio service provider
        await mediator.Send(new ServiceProviderOnBoardCompletedCommand(command.User.Id));

        return Results.Ok("OnBoard successfully processed.");
    }
}

public sealed class ServiceProviderOnBoardFormPaymentCommandValidator : AbstractValidator<ServiceProviderOnBoardFormPaymentCommand>
{
    public ServiceProviderOnBoardFormPaymentCommandValidator()
    {
        RuleFor(c => c.BankId).NotEmpty();
        RuleFor(c => c.Agency).NotEmpty();
        RuleFor(c => c.Account).NotEmpty();
        RuleForEach(c => c.Plans).NotEmpty();
    }
}