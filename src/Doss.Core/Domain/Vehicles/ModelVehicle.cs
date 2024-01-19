namespace Doss.Core.Domain.Vehicles;

public class ModelVehicle
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public Guid BrandVehicleId { get; set; }
    public BrandVehicle BrandVehicle { get; set; }

    public ModelVehicle() { }

    public ModelVehicle(Guid brandVehicleId, string description)
        => (BrandVehicleId, Description, Created) = (brandVehicleId, description, DateTime.Now);

    public void ChangeDescription(string description)
    {
        Description = description;
        Updated = DateTime.Now;
    }

    public void ChangeBrandVehicleId(Guid brandVehicleId)
    {
        BrandVehicleId = brandVehicleId;
        Updated = DateTime.Now;
    }
}