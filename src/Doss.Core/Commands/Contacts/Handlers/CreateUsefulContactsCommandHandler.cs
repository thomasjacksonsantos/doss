using Doss.Core.Commands.Contacts;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.OnBoard.Residentials.Handlers;

public class CreateUsefulContactsCommandHandler : BaseCommandHandler<CreateUsefulContactsCommand, CreateUsefulContactsCommandValidator>
{
    private readonly IUsefulContactRepository usefulContactRepository;

    public CreateUsefulContactsCommandHandler(IUsefulContactRepository usefulContactRepository,
                                              CreateUsefulContactsCommandValidator validator)
        : base(validator)
            => (this.usefulContactRepository) = (usefulContactRepository);

    public override async Task<Result> HandleImplementation(CreateUsefulContactsCommand command)
    {
         await usefulContactRepository.AddAsync(new Domain.Contacts.UsefulContact(command.Description, command.Number), saveChanges: true);    
        return Results.Ok("Useful created with successfully.");
    }
}

public sealed class CreateUsefulContactsCommandValidator : AbstractValidator<CreateUsefulContactsCommand>
{
    public CreateUsefulContactsCommandValidator()
    {
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Number).NotEmpty();
    }
}