using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Doss.Core.Commands.OnBoard.Residentials.Handlers;

public class ResidentialOnBoardAddressCommandHandler : BaseCommandHandler<ResidentialOnBoardAddressCommand, ResidentialAddressOnBoardCommandValidator>
{
    private readonly IOnBoardResidentialRepository onBoardResidentialRepository;
    private readonly IZipCodeRepository zipCodeRepository;

    public ResidentialOnBoardAddressCommandHandler(IOnBoardResidentialRepository onBoardResidentialRepository,
                                                   IZipCodeRepository zipCodeRepository,
                                                   ResidentialAddressOnBoardCommandValidator validator)
        : base(validator)
            => (this.onBoardResidentialRepository, this.zipCodeRepository) = (onBoardResidentialRepository, zipCodeRepository);

    public override async Task<Result> HandleImplementation(ResidentialOnBoardAddressCommand command)
    {
        var residentialOnBoard = await onBoardResidentialRepository.ReturnByIdAsync(command.User!.Id);
        if (residentialOnBoard.IsNull())
            return Results.Error("OnBoard not found.");

        var zipCode = await zipCodeRepository.SearchByZipCode(command.ZipCode);

        if (zipCode.IsSuccess is false)
            return Results.Error("Cep invalido.");

        residentialOnBoard.ChangeStep(OnBoardStepEnum.Address);

        if (residentialOnBoard.Address is not { })
            residentialOnBoard.AddAddress(new OnBoardAddress(command.Country,
                                                             command.State,
                                                             command.City,
                                                             command.Street,
                                                             command.Complement,
                                                             command.Neighborhood,
                                                             command.ZipCode.ConvertToInt(),
                                                             command.Number,
                                                             zipCode.Latitude ?? 0,
                                                             zipCode.Longitude ?? 0));
        else
        {
            residentialOnBoard.Address.ChangeCountry(command.Country);
            residentialOnBoard.Address.ChangeState(command.State);
            residentialOnBoard.Address.ChangeCity(command.City);
            residentialOnBoard.Address.ChangeStreet(command.Street);
            residentialOnBoard.Address.ChangeNeighborhood(command.Neighborhood);
            residentialOnBoard.Address.ChangeComplement(command.Complement);
            residentialOnBoard.Address.ChangeZipCode(command.ZipCode.ConvertToInt());
            residentialOnBoard.Address.ChangeNumber(command.Number);
            residentialOnBoard.Address.ChangeLatitude(zipCode.Latitude ?? 0);
            residentialOnBoard.Address.ChangeLongitude(zipCode.Longitude ?? 0);
        }

        await onBoardResidentialRepository.SaveAsync();
        return Results.Ok("OnBoard successfully processed.");
    }
}

public sealed class ResidentialAddressOnBoardCommandValidator : AbstractValidator<ResidentialOnBoardAddressCommand>
{
    public ResidentialAddressOnBoardCommandValidator()
    {
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.State).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.Street).NotEmpty();
        RuleFor(c => c.ZipCode).NotEmpty();
        RuleFor(c => c.Number).NotEmpty();
    }
}