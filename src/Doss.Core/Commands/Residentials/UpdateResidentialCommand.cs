using Doss.Core.Seedwork;

namespace Doss.Core.Commands.Users;

public class UpdateResidentialCommand : Command
{
    public Guid Id { get; set; }
    public string Document { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
    public IEnumerable<AddressCommand> Addresses { get; set; } = new List<AddressCommand>();
    public class AddressCommand
    {
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
