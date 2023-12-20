using Doss.Core.Commands.Contacts;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.OnBoard.Residentials.Handlers;

public class UpdateUsefulContactsCommandHandler : BaseCommandHandler<UpdateUsefulContactsCommand, UpdateUsefulContactsCommandValidator>
{
    private readonly IUsefulContactRepository usefulContactRepository;

    public UpdateUsefulContactsCommandHandler(IUsefulContactRepository usefulContactRepository,
                                              UpdateUsefulContactsCommandValidator validator)
        : base(validator)
            => (this.usefulContactRepository) = (usefulContactRepository);

    public override async Task<Result> HandleImplementation(UpdateUsefulContactsCommand command)
    {
        var usefulContact = await usefulContactRepository.ReturnByIdAsync(command.Id);
        usefulContact.ChangeStatus(command.Status);
        usefulContact.ChangeDescription(command.Description);
        usefulContact.ChangeNumber(command.Number);
        
        await usefulContactRepository.SaveAsync();

        return Results.Ok("Useful updated with successfully.");
    }
}

public sealed class UpdateUsefulContactsCommandValidator : AbstractValidator<UpdateUsefulContactsCommand>
{
    public UpdateUsefulContactsCommandValidator()
    {
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Number).NotEmpty();
    }
}