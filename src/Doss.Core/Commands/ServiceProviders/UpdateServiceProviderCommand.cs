using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.ServiceProviders;

public class UpdateServiceProviderCommand : Command
{
    public ServiceProviderCommand ServiceProvider { get; set; } = null!;
    public AddressCommand Address { get; set; } = null!;
    public CoverageCommand Coverage { get; set; } = null!;
    public FormPaymentCommand FormPayment { get; set; } = null!;

    public class ServiceProviderCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public TypeDocument TypeDocument { get; set; }
        public string Document { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
    }

    public class AddressCommand
    {
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
    }

    public class CoverageCommand
    {
        public int CoverageArea { get; set; }
    }

    public class FormPaymentCommand
    {
        public Guid BankId { get; set; }
        public string Agency { get; set; } = string.Empty;
        public string Account { get; set; } = string.Empty;
        public IEnumerable<PlanCommand> Plans { get; set; } = new List<PlanCommand>();
    }

    public class PlanCommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
