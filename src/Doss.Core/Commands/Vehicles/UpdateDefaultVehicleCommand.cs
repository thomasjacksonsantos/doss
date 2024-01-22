using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Vehicles
{
    public class UpdateDefaultVehicleCommand : Command
    {
        public Guid VehicleId { get; set; }
        public bool DefaultVehicle { get; set; }
    }
}
