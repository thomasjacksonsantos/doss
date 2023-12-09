namespace Doss.Core.Domain.ServiceProviders;

public class ServiceProviderAlert
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public DateTime Created { get; private set; }

    public ServiceProviderAlert(string description)
        => (Description,  Created) = (description, DateTime.Now);
}