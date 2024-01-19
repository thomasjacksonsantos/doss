using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Vehicles
{
    public class UpdateResidentialVehicleCommand : Command
    {
        public Guid Id { get; set; }
        public Guid ResidentialWithServiceProviderId { get; set; }
        public Guid ModelVehicleId { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public bool DefaultVehicle { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
