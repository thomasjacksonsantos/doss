using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Vehicles
{
    public class UpdateModelVehicleCommand : Command
    {
        public Guid Id { get; set; }
        public Guid BrandVehicleId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
