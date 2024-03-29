
using Doss.Core.Domain.Enums;

namespace Doss.Core.Domain.OnBoard;

public class OnBoardVehicle
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string Plate { get; set; }
    public string Photo { get; set; }
    public bool DefaultVehicle { get; set; }
    public VehicleType VehicleType { get; set; }

    public OnBoardVehicle(string brand, string model, string color, string plate, string photo, bool defaultVehicle, VehicleType vehicleType)
        => (Brand, Model, Color, Plate, Photo, DefaultVehicle, VehicleType) = (brand, model, color, plate, photo, defaultVehicle, vehicleType);


    public void ChangeBrand(string brand)
        => Brand = brand;

    public void ChangeModel(string model)
        => Model = model;

    public void ChangeColor(string color)
        => Color = color;
    public void ChangePhoto(string photo)
        => Photo = photo;

    public void ChangePlate(string plate)
        => Plate = plate;

    public void ChangeDefaultVehicle(bool defaultVehicle)
        => DefaultVehicle = defaultVehicle;

    public void ChangeVehicleType(VehicleType vehicleType)
        => VehicleType = vehicleType;
}