

namespace Doss.Core.Domain.Vehicles;

public class TypeVehicle
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public TypeVehicle() { }

    public TypeVehicle(string description)
        => (Description, Created) = (description, DateTime.Now);
    
    public void ChangeDescription(string description)
    {
        Description = description;
        Updated = DateTime.Now;
    }
}