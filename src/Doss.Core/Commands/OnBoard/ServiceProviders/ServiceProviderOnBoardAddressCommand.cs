using Doss.Core.Seedwork;

namespace Doss.Core.Commands.OnBoard.ServiceProviders;

public class ServiceProviderOnBoardAddressCommand : Command
{
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
}