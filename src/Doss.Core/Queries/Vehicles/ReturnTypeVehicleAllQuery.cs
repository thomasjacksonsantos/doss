using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Vehicles;

public class ReturnTypeVehicleAllQuery : Query<ReturnTypeVehicleAllQuery.Response>
{
    public class Response
    {
        public IEnumerable<TypeVehicle> TypeVehicles { get; set; }
        public Response(IEnumerable<TypeVehicle> typeVehicles)
             => TypeVehicles = typeVehicles;
    }

    public class TypeVehicle
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public TypeVehicle(Guid id, string description)
            => (Id, Description) = (id, description);
    }
}