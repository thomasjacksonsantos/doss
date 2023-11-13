using Doss.Core.Domain.Banks;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.Banks.Handlers;
public class UpsertBankCommandHandler: BaseCommandHandler<UpsertBankCommand, UpsertBankCommandValidator>
{
    private readonly IBankRepository bankRepository;

    public UpsertBankCommandHandler(IBankRepository bankRepository, UpsertBankCommandValidator validator)
        : base(validator)
            => this.bankRepository = bankRepository;

    public override async Task<Result> HandleImplementation(UpsertBankCommand command)
    {
        if (command.Id.HasValue is false)
        {
            await bankRepository.AddAsync(new Bank(command.Name, command.BankStatus), saveChanges: true);
            return Results.Ok("Bank created with success.");
        }

        var bank = await bankRepository.ReturnByIdAsync(command.Id!.Value);

        bank.ChangeName(command.Name);
        bank.ChangeBankStatus(command.BankStatus);

        await bankRepository.SaveAsync();

        return Results.Ok("Bank updated with success.");
    }
}

public sealed class UpsertBankCommandValidator : AbstractValidator<UpsertBankCommand>
{
    public UpsertBankCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.BankStatus).NotEmpty();
    }
}