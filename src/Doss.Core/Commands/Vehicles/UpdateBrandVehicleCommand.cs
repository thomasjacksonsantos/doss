using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Vehicles
{
    public class UpdateBrandVehicleCommand : Command
    {
        public Guid Id { get; set; }
        public Guid TypeVehicleId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
