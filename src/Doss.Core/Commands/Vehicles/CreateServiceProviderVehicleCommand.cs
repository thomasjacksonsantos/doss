using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Vehicles
{
    public class CreateServiceProviderVehicleCommand : Command
    {
         public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public bool DefaultVehicle { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
