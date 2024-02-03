using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Vehicles
{
    public class UpdatePhotoVehicleCommand : Command
    {
        public Guid Id { get; set; }
        public string Photo { get; set; } = string.Empty;
    }
}
