namespace Doss.Infra.Seedwork;

public class BaseHttpRepository
{
    protected readonly HttpClient Client;

    public BaseHttpRepository(IHttpClientFactory factory, string serviceName)
        => Client = factory.CreateClient(serviceName);
}