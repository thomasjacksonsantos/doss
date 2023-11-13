using Doss.Core.Seedwork;

namespace Doss.Core.Commands.ServiceProviders
{
    public class ServiceProviderPlanCommand : Command
    {
        public decimal Price { get; set; }
        public PlanAccountBankCommand PlanAccountBank { get; set; } = new PlanAccountBankCommand();
        public class PlanAccountBankCommand
        {
            public Guid BankId { get; set; }
            public string Agency { get; set; } = string.Empty;
            public string Account { get; set; } = string.Empty;
        }
    }
}
