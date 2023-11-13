
namespace Doss.Core.Domain.OnBoard;

public class OnBoardPlan
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public OnBoardPlan(string description, decimal price)
        => (Description, Price) = (description, price);

    public void ChangeDescription(string description)
        => Description = description;

    public void ChangePrice(decimal price)
        => Price = price;
}