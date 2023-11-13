using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Residentials;

public class CreateResidentialAfterOnBoardCommand : Command
{
    public string Document { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
    public IEnumerable<AddressCommand> Addresses { get; set; } = new List<AddressCommand>();
    public Guid GuardId { get; set; }
    public Guid PlanId { get; set; }

    public class AddressCommand
    {
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
    }
}
