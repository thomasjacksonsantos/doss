using Doss.Core.Seedwork;

namespace Doss.Core.Queries.Vehicles;

public class ReturnBrandVehicleAllQuery : Query<ReturnBrandVehicleAllQuery.Response>
{
    public Guid TypeVehicleId { get; set; }
    public class Response
    {
        public IEnumerable<BrandVehicle> BrandVehicles { get; set; }
        public Response(IEnumerable<BrandVehicle> brandVehicles)
             => BrandVehicles = brandVehicles;
    }

    public class BrandVehicle
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public BrandVehicle(Guid id, string description)
            => (Id, Description) = (id, description);
    }
}