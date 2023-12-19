
namespace Doss.Core.Domain.Vehicles;

public class UserVehicle
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public DateTime Created { get; set; }

    public UserVehicle() { }

    public UserVehicle(Vehicle vehicle)
        => (Vehicle) = (vehicle);
}