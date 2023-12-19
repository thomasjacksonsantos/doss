
namespace Doss.Core.Domain.Vehicles;

public class ServiceProviderVehicle
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public Guid ServiceProviderId { get; set; }
    public Vehicle Vehicle { get; set; }
    public DateTime Created { get; set; }

    public ServiceProviderVehicle() { }

    public ServiceProviderVehicle(Vehicle vehicle)
        => (Vehicle, Created) = (vehicle, DateTime.Now);
}