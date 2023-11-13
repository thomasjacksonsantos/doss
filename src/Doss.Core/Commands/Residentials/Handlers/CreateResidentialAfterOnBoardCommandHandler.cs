using Doss.Core.Commands.Residentials;
using Doss.Core.Domain.Users;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.Residentials.Handlers;

public class CreateResidentialAfterOnBoardCommandHandler : BaseCommandHandler<CreateResidentialAfterOnBoardCommand, CreateResidentialAfterOnBoardCommandValidator>
{
    private readonly IResidentialRepository residentialRepository;
    private readonly IServiceProviderRepository serviceProviderRepository;

    public CreateResidentialAfterOnBoardCommandHandler(IResidentialRepository residentialRepository, IServiceProviderRepository serviceProviderRepository, CreateResidentialAfterOnBoardCommandValidator validator)
        : base(validator)
            => (this.residentialRepository, this.serviceProviderRepository) = (residentialRepository, serviceProviderRepository);

    public override async Task<Result> HandleImplementation(CreateResidentialAfterOnBoardCommand command)
    {
        var guard = await serviceProviderRepository.ReturnByIdAsync(command.GuardId);
        // await residentialRepository.AddAsync(new Residential(new User(command.User!.Name, command.Document, command.Phone, command.Photo, false), new List<Guard> { guard }));
        await residentialRepository.SaveAsync();

        return Results.Ok("Residentia user created with success.");
    }
}

public sealed class CreateResidentialAfterOnBoardCommandValidator : AbstractValidator<CreateResidentialAfterOnBoardCommand>
{
    public CreateResidentialAfterOnBoardCommandValidator()
    {
        RuleFor(c => c.Document).NotEmpty();
        RuleForEach(c => c.Addresses)
            .SetValidator(new CreateResidentialOnBoardAddressesComandValidator());
    }
}

public sealed class CreateResidentialOnBoardAddressesComandValidator : AbstractValidator<CreateResidentialAfterOnBoardCommand.AddressCommand>
{
    public CreateResidentialOnBoardAddressesComandValidator()
    {
        RuleFor(c => c.State).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.Neighborhood).NotEmpty();
        RuleFor(c => c.Street).NotEmpty();
        RuleFor(c => c.Number).NotEmpty();
    }
}