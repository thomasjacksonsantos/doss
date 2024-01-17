using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Vehicles;

public class ReturnVehicleByIdQuery : Query<ReturnVehicleByIdQuery.Response>
{
    public Guid Id { get; set; }
    
    public class Response
    {
        public Vehicle Vehicle { get; set; }
        public Response(Vehicle vehicle)
             => Vehicle = vehicle;
    }

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

        public Vehicle(Guid id, string brand, string model, string color, string plate, string photo, bool defaultVehicle, VehicleType vehicleType, DateTime created, DateTime? updated = null)
            => (Id, Brand, Model, Color, Plate, Photo, DefaultVehicle, VehicleType, Created, Updated)
                = (id, brand, model, color, plate, photo, defaultVehicle, vehicleType, created, updated);
    }
}