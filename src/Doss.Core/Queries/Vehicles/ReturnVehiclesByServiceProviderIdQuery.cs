using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Vehicles;

public class ReturnVehiclesByServiceProviderIdQuery : Query<ReturnVehiclesByServiceProviderIdQuery.Response>
{
    public int Page { get; set; }
    public int Total { get; set; }

    public class Response
    {

        public IEnumerable<Vehicle> Vehicles { get; set; }
        public Response(IEnumerable<Vehicle> vehicles)
             => Vehicles = vehicles;
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
        public VehicleStatus VehicleStatus { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public Vehicle(Guid id, string brand, string model, string color, string plate, string photo, bool defaultVehicle, VehicleType vehicleType, VehicleStatus vehicleStatus, DateTime created, DateTime? updated = null)
            => (Id, Brand, Model, Color, Plate, Photo, DefaultVehicle, VehicleType, VehicleStatus, Created, Updated)
                = (id, brand, model, color, plate, photo, defaultVehicle, vehicleType, vehicleStatus, created, updated);
    }
}