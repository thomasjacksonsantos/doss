using Doss.Core.Commands.OnBoard.ServiceProviders;
using Doss.Core.Domain.OnBoard;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.OnBoard.ServiceProviders.Handlers;

public class ServiceProviderOnBoardAddressCommandHandler : BaseCommandHandler<ServiceProviderOnBoardAddressCommand, ServiceProviderOnBoardAddressCommandValidator>
{
    private readonly IOnBoardServiceProviderRepository onBoardServiceProviderRepository;
    private readonly IZipCodeRepository zipCodeRepository;

    public ServiceProviderOnBoardAddressCommandHandler(IOnBoardServiceProviderRepository onBoardServiceProviderRepository,
                                                       IZipCodeRepository zipCodeRepository,
                                                       ServiceProviderOnBoardAddressCommandValidator validator)
        : base(validator)
            => (this.onBoardServiceProviderRepository, this.zipCodeRepository) = (onBoardServiceProviderRepository, zipCodeRepository);

    public override async Task<Result> HandleImplementation(ServiceProviderOnBoardAddressCommand command)
    {
        var serviceProviderOnBoard = await onBoardServiceProviderRepository.ReturnByIdAsync(command.User!.Id);
        if (serviceProviderOnBoard.IsNull())
            return Results.Error("OnBoard not found.");

        var zipCode = await zipCodeRepository.SearchByZipCode(command.ZipCode);

        if (zipCode.IsSuccess is false)
            return Results.Error("Cep invalido.");

        serviceProviderOnBoard.ChangeStep(OnBoardStepEnum.Address);

        if (serviceProviderOnBoard.Address is not { })
            serviceProviderOnBoard.AddAddress(new OnBoardAddress(command.Country,
                                                             command.State,
                                                             command.City,
                                                             command.Street,
                                                             command.Complement,
                                                             command.ZipCode,
                                                             command.Number,
                                                             zipCode.Latitude ?? 0,
                                                             zipCode.Longitude ?? 0));
        else
        {
            serviceProviderOnBoard.Address.ChangeCountry(command.Country);
            serviceProviderOnBoard.Address.ChangeState(command.State);
            serviceProviderOnBoard.Address.ChangeCity(command.City);
            serviceProviderOnBoard.Address.ChangeStreet(command.Street);
            serviceProviderOnBoard.Address.ChangeComplement(command.Complement);
            serviceProviderOnBoard.Address.ChangeZipCode(command.ZipCode);
            serviceProviderOnBoard.Address.ChangeLatitude(zipCode.Latitude ?? 0);
            serviceProviderOnBoard.Address.ChangeLongitude(zipCode.Longitude ?? 0);
        }

        await onBoardServiceProviderRepository.SaveAsync();
        return Results.Ok("OnBoard successfully processed.");
    }
}

public sealed class ServiceProviderOnBoardAddressCommandValidator : AbstractValidator<ServiceProviderOnBoardAddressCommand>
{
    public ServiceProviderOnBoardAddressCommandValidator()
    {
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.State).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.Street).NotEmpty();
        RuleFor(c => c.ZipCode).NotEmpty();
        RuleFor(c => c.Number).NotEmpty();
    }
}