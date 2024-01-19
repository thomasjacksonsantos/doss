using Doss.Core.Seedwork;

namespace Doss.Core.Commands.OnBoard.ServiceProviders;

public class ServiceProviderOnBoardVehicleCommand : Command
{
        public Guid ModelVehicleId { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Plate { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public bool DefaultVehicle { get; set; }
}