using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Vehicles
{
    public class UpdateStatusVehicleCommand : Command
    {
        public Guid VehicleId { get; set; }
        public VehicleStatus VehicleStatus { get; set; }
    }
}
