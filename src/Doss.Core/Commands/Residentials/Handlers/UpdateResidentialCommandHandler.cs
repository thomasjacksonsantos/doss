using Doss.Core.Commands.Users;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.Vehicles.Handlers;

public class UpdateResidentialCommandHandler : BaseCommandHandler<UpdateResidentialCommand, UpdateResidentialCommandValidator>
{
    private readonly IResidentialRepository residentialRepository;
    public UpdateResidentialCommandHandler(IResidentialRepository residentialRepository, UpdateResidentialCommandValidator validator)
        : base(validator)
            => this.residentialRepository = residentialRepository;

    public override async Task<Result> HandleImplementation(UpdateResidentialCommand command)
    {
        var residential = await residentialRepository.ReturnResidentialByIdAsync(command.Id);

        residential.AddAddress(command.Addresses
                                            .Select(c => new Doss.Core.Domain.Addresses.Address(c.Country, c.State, c.City, c.Street, c.Complement, c.ZipCode, c.Latitude, c.Longitude))
                                            .ToList());

        return Results.Ok("Residentia user updated with success.");
    }
}

public sealed class UpdateResidentialCommandValidator : AbstractValidator<UpdateResidentialCommand>
{
    public UpdateResidentialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Document).NotEmpty();
        RuleForEach(c => c.Addresses)
            .SetValidator(new UpdateResidentialAddressesComandValidator());
    }
}

public sealed class UpdateResidentialAddressesComandValidator : AbstractValidator<UpdateResidentialCommand.AddressCommand>
{
    public UpdateResidentialAddressesComandValidator()
    {
        RuleFor(c => c.State).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.Neighborhood).NotEmpty();
        RuleFor(c => c.Street).NotEmpty();
        RuleFor(c => c.Number).NotEmpty();
        RuleFor(c => c.Latitude).NotEmpty();
        RuleFor(c => c.Longitude).NotEmpty();
    }
}