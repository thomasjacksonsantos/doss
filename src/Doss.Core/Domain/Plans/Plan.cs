using Doss.Core.Domain.Enums;

namespace Doss.Core.Domain.Plans;

public class Plan
{
    public Guid Id { get; private set; }
    public string Description { get; set; }
    public decimal Price { get; private set; }
    public PlanStatus PlanStatus { get; private set; }
    public DateTime Created { get; private set; }
    public DateTime Updated { get; private set; }

    public Plan(string description, decimal price)
        => (Id, Description, Price, PlanStatus, Created) = (Guid.NewGuid(), description, price, PlanStatus.Active, DateTime.Now);

    public void ChangePrice(decimal price)
    {
        Price = price;
        Updated = DateTime.Now;
    }

    public void ChangePlanStatus(PlanStatus status)
    {
        PlanStatus = status;
        Updated = DateTime.Now;
    }
}