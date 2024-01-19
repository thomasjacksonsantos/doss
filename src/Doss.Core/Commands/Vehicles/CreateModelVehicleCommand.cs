using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Vehicles
{
    public class CreateModelVehicleCommand : Command
    {
        public Guid BrandVehicleId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
