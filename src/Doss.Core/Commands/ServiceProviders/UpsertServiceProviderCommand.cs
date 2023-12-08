using Doss.Core.Domain.Enums;
using Doss.Core.Seedwork;

namespace Doss.Core.Commands.ServiceProviders;

public class UpsertServiceProviderCommand : Command
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public TypeDocument TypeDocument { get; set; }
    public string Document { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
    public bool CompletedRegistration { get; set; }
    public UserStatus UserStatus { get; set; }
}
