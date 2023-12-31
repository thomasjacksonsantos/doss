
namespace Doss.Core.Domain.Vehicles;

public class ResidentialVehicle
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public Guid ResidentialId { get; set; }
    public Guid ResidentialWithServiceProviderId { get; set; }
    public Vehicle Vehicle { get; set; }
    public DateTime Created { get; set; }

    public ResidentialVehicle() { }

    public ResidentialVehicle(Guid residentialWithServiceProviderId, Vehicle vehicle)
        => (ResidentialWithServiceProviderId, Vehicle, Created) = (residentialWithServiceProviderId, vehicle, DateTime.Now);
}