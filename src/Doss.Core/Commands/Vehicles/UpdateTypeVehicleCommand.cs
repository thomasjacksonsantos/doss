using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Vehicles
{
    public class UpdateTypeVehicleCommand : Command
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
