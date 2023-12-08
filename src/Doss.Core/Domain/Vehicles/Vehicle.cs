using Doss.Core.Domain.Enums;
using Doss.Core.Domain.OnBoard;

namespace Doss.Core.Domain.Vehicles;

public class Vehicle
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string Plate { get; set; }
    public string Photo { get; set; }
    public bool DefaultVehicle { get; set; }
    public VehicleType VehicleType { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public Vehicle(string brand, string model, string color, string plate, string photo, bool defaultVehicle, VehicleType vehicleType)
        => (Id, Brand, Model, Color, Plate, Photo, DefaultVehicle, VehicleType, Created)
            = (Guid.NewGuid(), brand, model, color, plate, photo, defaultVehicle, vehicleType, DateTime.Now);

    public Vehicle(Guid id, string brand, string model, string color, string plate, string photo, bool defaultVehicle, VehicleType vehicleType)
        => (Id, Brand, Model, Color, Plate, Photo, DefaultVehicle, VehicleType, Updated)
            = (id, brand, model, color, plate, photo, defaultVehicle, vehicleType, DateTime.Now);

    public void SetUpdateDate(DateTime datetime)
        => Updated = datetime;

    public static implicit operator Vehicle(OnBoardVehicle vehicle)
        => new Vehicle(vehicle.Brand, vehicle.Model, vehicle.Color, vehicle.Plate, vehicle.Photo, vehicle.DefaultVehicle, vehicle.VehicleType);
}