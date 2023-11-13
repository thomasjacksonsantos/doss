using Doss.Core.Seedwork;

namespace Doss.Core.Commands.OnBoard.ServiceProviders;

public class ServiceProviderOnBoardFormPaymentCommand : Command
{
        public Guid BankId { get; set; }
        public string Agency { get; set; } = string.Empty;
        public string Account { get; set; } = string.Empty;
        public IEnumerable<Plan> Plans { get; set; } = new List<Plan>();
        public class Plan
        {
                public string Description { get; set; } = string.Empty;
                public decimal Price { get; set; }
        }
}