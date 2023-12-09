using Doss.Core.Domain.Addresses;
using Doss.Core.Domain.Banks;
using Doss.Core.Domain.Plans;

namespace Doss.Core.Domain.ServiceProviders;

public class ServiceProviderPlan
{
    public Guid Id { get; private set; }
    public Guid ServiceProviderId { get; private set; }
    public Guid BankId { get; private set; }
    public Bank Bank { get; private set; } = null!;
    public string AccountBank { get; private set; }
    public string AgencyBank { get; private set; }
    public ServiceProvider ServiceProvider { get; private set; } = null!;
    public IEnumerable<Plan> Plans { get; private set; } = new List<Plan>();
    public Address Address { get; private set; } = null!;
    public int CoverageArea { get; private set; }
    public DateTime Created { get; private set; }

    public ServiceProviderPlan(string accountBank, string agencyBank, int coverageArea)
        => (AccountBank, AgencyBank, CoverageArea, Created) = (accountBank, agencyBank, coverageArea, DateTime.Now);

    public ServiceProviderPlan(string accountBank, string agencyBank, int coverageArea, Address address, Bank bank, IEnumerable<Plan> plans)
        => (AccountBank, AgencyBank, CoverageArea, Address, Bank, Plans, Created) = (accountBank, agencyBank, coverageArea, address, bank, plans, DateTime.Now);

    public void AddPlans(IEnumerable<Plan> plans)
        => Plans = plans;

    public void AddBank(Bank bank)
    {
        BankId = bank.Id;
        Bank = bank;
    }

    public void AddAddress(Address address)
        => Address = address;
}