using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using Doss.Core.Services;
using FluentValidation;

namespace Doss.Core.Commands.ServiceProviders.Handlers;

public class UpdateServiceProviderCommandHandler : BaseCommandHandler<UpdateServiceProviderCommand, UpdateServiceProviderCommandValidator>
{
    private readonly IServiceProviderRepository serviceProviderRepository;
    private readonly IBlobStorage blobStorage;
    private readonly IZipCodeRepository zipCodeRepository;
    private readonly IBankRepository bankRepository;

    public UpdateServiceProviderCommandHandler(IServiceProviderRepository serviceProviderRepository,
                                               IBlobStorage blobStorage,
                                               IZipCodeRepository zipCodeRepository,
                                               IBankRepository bankRepository,
                                               UpdateServiceProviderCommandValidator validator)
        : base(validator)
            => (this.serviceProviderRepository, this.blobStorage, this.zipCodeRepository, this.bankRepository)
                = (serviceProviderRepository, blobStorage, zipCodeRepository, bankRepository);

    public override async Task<Result> HandleImplementation(UpdateServiceProviderCommand command)
    {
        var serviceProvider = await serviceProviderRepository.ReturnByIdAsync(command.User!.Id);

        if (serviceProvider.IsNull())
            return Results.Error("Service provider not found.");

        serviceProvider.ChangeName(command.ServiceProvider.Name);
        serviceProvider.ChangeTypeDocument(command.ServiceProvider.TypeDocument);
        serviceProvider.ChangeDocument(command.ServiceProvider.Document);
        serviceProvider.ChangePhone(command.ServiceProvider.Phone);

        if (command.ServiceProvider.Photo.IsNotNullOrEmpty())
        {
            var url = $"service-provider/image/{Guid.NewGuid()}";
            serviceProvider.ChangePhotoUrl(url);
            await blobStorage.SendImage(command.ServiceProvider.Photo, url);
        }

        /// Hoje vamos deixar como padrao somente um serviceProviderPlan por serviceProvider.
        /// Mas com o ServiceProviderPlan temos a possibilidade de atender varios moradores de lugares diferente e com planos diferentes tbm.
        /// 
        var serviceProviderPlan = serviceProvider.ServiceProviderPlans.First();

        /// Address
        var zipCode = await zipCodeRepository.SearchByZipCode(command.Address.ZipCode);

        if (zipCode.IsSuccess is false)
            return Results.Error("Cep invalido.");

        serviceProviderPlan.ChangeAddress(new Domain.Addresses.Address(command.Address.Country,
                                                                        command.Address.State,
                                                                        command.Address.City,
                                                                        command.Address.Street,
                                                                        command.Address.Neighborhood,
                                                                        command.Address.Complement,
                                                                        command.Address.ZipCode,
                                                                        command.Address.Number,
                                                                        zipCode.Latitude ?? 0,
                                                                        zipCode.Longitude ?? 0));

        /// Coverage
        serviceProviderPlan.ChangeCoverage(command.Coverage.CoverageArea);

        /// Bank
        var bank = await bankRepository.ReturnByIdAsync(command.FormPayment.BankId);

        serviceProviderPlan.ChangeBank(bank);
        serviceProviderPlan.ChangeAccountBank(command.FormPayment.Account);
        serviceProviderPlan.ChangeAgencyBank(command.FormPayment.Agency);

        command.FormPayment.Plans.ForEach(c =>
        {
            var plan = serviceProviderPlan.Plans.First(p => p.Id == c.Id);
            plan.ChangeDescription(c.Description);
            plan.ChangePrice(c.Price);
        });

        await serviceProviderRepository.SaveAsync();

        return Results.Ok("Service provider executed with success.");
    }
}

public sealed class UpdateServiceProviderCommandValidator : AbstractValidator<UpdateServiceProviderCommand>
{
    public UpdateServiceProviderCommandValidator()
    {
        RuleFor(c => c.ServiceProvider).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Coverage).NotEmpty();
        RuleFor(c => c.FormPayment).NotEmpty();
    }
}