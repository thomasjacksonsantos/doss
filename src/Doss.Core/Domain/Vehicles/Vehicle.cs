using Doss.Core.Domain.Enums;
using Doss.Core.Domain.OnBoard;

namespace Doss.Core.Domain.Vehicles;

public class Vehicle
{
    public Guid Id { get; set; }
    public string Color { get; set; }
    public string Plate { get; set; }
    public string Photo { get; set; }
    public bool DefaultVehicle { get; set; }
    public Guid ModelVehicleId { get; set; }
    public ModelVehicle ModelVehicle { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }

    public Vehicle() { }
    public Vehicle(Guid modelVeichelId, string color, string plate, string photo, bool defaultVehicle)
        => (ModelVehicleId, Color, Plate, Photo, DefaultVehicle, Created)
            = (modelVeichelId, color, plate, photo, defaultVehicle, DateTime.Now);

    // public Vehicle(Guid id, Guid modelVeichelId, string color, string plate, string photo, bool defaultVehicle, VehicleType vehicleType)
    //     => (Id, ModelVehicleId, Color, Plate, Photo, DefaultVehicle, Updated)
    //         = (id, modelVeichelId, color, plate, photo, defaultVehicle, DateTime.Now);

    public void ChangeDate(DateTime datetime)
        => Updated = datetime;

    public void ChangePhoto(string photo)
        => Photo = photo;

    public void ChangeDefaultVehicle(bool defaultVehicle)
        => DefaultVehicle = defaultVehicle;

    public void ChangeModelVehicle(Guid modelVehicleId)
        => ModelVehicleId = modelVehicleId;

    public void ChangeColor(string color)
        => Color = color;

    public void ChangePlate(string plate)
        => Plate = plate;

    public static implicit operator Vehicle(OnBoardVehicle vehicle)
        => new Vehicle(vehicle.ModelVehicleId, vehicle.Color, vehicle.Plate, vehicle.Photo, vehicle.DefaultVehicle);
}