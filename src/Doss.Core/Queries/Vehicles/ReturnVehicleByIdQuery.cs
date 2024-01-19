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
        public Guid TypeVehicleId { get; set; }
        public Guid BrandVehicleId { get; set; }
        public Guid ModelVehicleId { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
        public string Photo { get; set; }
        public bool DefaultVehicle { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public Vehicle(Guid id, Guid typeVehicleId, Guid brandVehicleId, Guid modelVehicleId, string color, string plate, string photo, bool defaultVehicle, DateTime created, DateTime? updated = null)
            => (Id, TypeVehicleId, BrandVehicleId, ModelVehicleId, Color, Plate, Photo, DefaultVehicle, Created, Updated)
                = (id, typeVehicleId, brandVehicleId, modelVehicleId, color, plate, photo, defaultVehicle, created, updated);
    }
}