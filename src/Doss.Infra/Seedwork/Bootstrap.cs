using Doss.Core.Services;
using Doss.Infra.Repositories;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Doss.Infra.Seedwork;

public static class Bootstrap
{
    public static void InitInfra(this IServiceCollection service, IConfiguration configuration)
    {
        service.ConfigureInfra();
        service.ConfigureBlobStorage();
        service.ConfigureServiceBus(configuration);
    }

    public static void ConfigureBlobStorage(this IServiceCollection service)
        => service.AddScoped<IBlobStorage, BlobStorage>();

    public static void ConfigureServiceBus(this IServiceCollection service, IConfiguration configuration)
        => service.AddAzureClients(builder => builder.AddServiceBusClient(configuration.GetConnectionString("ServiceBus")));

    private static void ConfigureInfra(this IServiceCollection service)
    {
        var repositoryAssembly = typeof(RepositoryBase<>).Assembly;
        var registrationsRepository = from type in repositoryAssembly.GetExportedTypes()
                                      where
                                          type.Namespace!.Contains("Doss.Infra.Repositories") && !type.IsGenericType
                                      where type.GetInterfaces().Any(x => !x.IsGenericType)
                                      select new { Service = type.GetInterfaces().Single(x => !x.IsGenericType), Implementation = type };

        foreach (var reg in registrationsRepository)
            service.AddScoped(reg.Service, reg.Implementation);
    }
}