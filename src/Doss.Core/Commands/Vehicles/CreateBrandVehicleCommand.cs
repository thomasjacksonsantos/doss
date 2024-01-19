using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Vehicles
{
    public class CreateBrandVehicleCommand : Command
    {
        public Guid TypeVehicleId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
