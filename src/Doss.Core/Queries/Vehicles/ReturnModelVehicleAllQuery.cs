using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Vehicles;

public class ReturnModelVehicleAllQuery : Query<ReturnModelVehicleAllQuery.Response>
{
    public Guid BrandVehicleId { get; set; }
    public class Response
    {
        public IEnumerable<ModelVehicle> ModelVehicles { get; set; }
        public Response(IEnumerable<ModelVehicle> modelVehicles)
             => ModelVehicles = modelVehicles;
    }

    public class ModelVehicle
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public ModelVehicle(Guid id, string description)
            => (Id, Description) = (id, description);
    }
}