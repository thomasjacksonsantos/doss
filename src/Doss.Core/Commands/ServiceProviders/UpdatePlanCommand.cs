using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.ServiceProviders
{
    public class UpdatePlanCommand : Command
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public PlanStatus PlanStatus { get; set; }
        public PlanAccountBankCommand PlanAccountBank { get; set; } = new PlanAccountBankCommand();
        public class PlanAccountBankCommand
        {
            public Guid BankId { get; set; }
            public string Agency { get; set; } = string.Empty;
            public string Account { get; set; } = string.Empty;
        }
    }
}
