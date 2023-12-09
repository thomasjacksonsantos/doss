using Doss.Core.Commands.ServiceProviders;
using Doss.Core.Domain.ServiceProviders;
using Doss.Core.Interfaces.Repositories;
using Doss.Core.Seedwork;
using FluentValidation;

namespace Ageu.Core.Commands.ServiceProviders.Handlers;

public class ServiceProviderAlertCommandHandler : BaseCommandHandler<ServiceProviderAlertCommand, ServiceProviderAlertCommandValidator>
{
    private readonly IServiceProviderAlertRepository serviceProviderAlertRepository;
    public ServiceProviderAlertCommandHandler(IServiceProviderAlertRepository serviceProviderAlertRepository,
                                                ServiceProviderAlertCommandValidator validator)
        : base(validator)
            => (this.serviceProviderAlertRepository) = (serviceProviderAlertRepository);

    public override async Task<Result> HandleImplementation(ServiceProviderAlertCommand command)
    {
        await serviceProviderAlertRepository.AddAsync(new ServiceProviderAlert(command.Description));
        await serviceProviderAlertRepository.SaveAsync();
        return Results.Ok("Alert created with success.");
    }
}

public sealed class ServiceProviderAlertCommandValidator : AbstractValidator<ServiceProviderAlertCommand>
{
    public ServiceProviderAlertCommandValidator()
    {
        RuleFor(c => c.Description).NotEmpty().Length(100);
    }
}