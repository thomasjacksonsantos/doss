
using Doss.Core.Domain.Enums;
using Doss.Core.Domain.Vehicles;

namespace Doss.Core.Domain.OnBoard;

public class OnBoardVehicle
{
    public Guid Id { get; set; }
    public Guid ModelVehicleId { get; set; }
    public string Color { get; set; }
    public string Plate { get; set; }
    public string Photo { get; set; }
    public bool DefaultVehicle { get; set; }

    public OnBoardVehicle(Guid modelVehicleId, string color, string plate, string photo, bool defaultVehicle)
        => (ModelVehicleId, Color, Plate, Photo, DefaultVehicle) = (modelVehicleId, color, plate, photo, defaultVehicle);

    public void ChangeModelVehicle(Guid modelVehicleId)
        => ModelVehicleId = modelVehicleId;

    public void ChangeColor(string color)
        => Color = color;

    public void ChangePlate(string plate)
        => Plate = plate;

    public void ChangePhoto(string photo)
        => Photo = photo;

    public void ChangeDefaultVehicle(bool defaultVehicle)
        => DefaultVehicle = defaultVehicle;
}