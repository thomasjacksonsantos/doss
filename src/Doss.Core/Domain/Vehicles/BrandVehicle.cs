


namespace Doss.Core.Domain.Vehicles;

public class BrandVehicle
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public Guid TypeVehicleId { get; set; }
    public TypeVehicle TypeVehicle { get; set; }

    public BrandVehicle() { }

    public BrandVehicle(Guid typeVehicleId, string description)
        => (TypeVehicleId, Description, Created) = (typeVehicleId, description, DateTime.Now);

    public void ChangeDescription(string description)
    {
        Description = description;
        Updated = DateTime.Now;
    }

    public void ChangeTypeVehicleId(Guid typeVehicleId)
    {
        TypeVehicleId = typeVehicleId;
        Updated = DateTime.Now;
    }
}