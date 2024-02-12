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
    public string PhotoUrl { get; set; }
    public bool DefaultVehicle { get; set; }
    public VehicleType VehicleType { get; set; }
    public VehicleStatus VehicleStatus { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public Vehicle(string brand, string model, string color, string plate, bool defaultVehicle, VehicleType vehicleType)
        => (Brand, Model, Color, Plate, PhotoUrl, DefaultVehicle, VehicleType, VehicleStatus, Created)
            = (brand, model, color, plate, string.Empty, defaultVehicle, vehicleType, VehicleStatus.Active, DateTime.Now);

    public void ChangeDate(DateTime datetime)
        => Updated = datetime;

    public void ChangeDefaultVehicle(bool defaultVehicle)
        => DefaultVehicle = defaultVehicle;

    public void ChangeVehicleType(VehicleType vehicleType)
            => VehicleType = vehicleType;

    public void ChangeBrand(string brand)
        => Brand = brand;

    public void ChangeModel(string model)
        => Model = model;
    public void ChangeColor(string color)
        => Color = color;

    public void ChangePlate(string plate)
        => Plate = plate;

    public void ChangePhotoUrl(string url)
        => PhotoUrl = url;

    public static implicit operator Vehicle(OnBoardVehicle vehicle)
      => new Vehicle(vehicle.Brand, vehicle.Model, vehicle.Color, vehicle.Plate, vehicle.DefaultVehicle, vehicle.VehicleType);
}