
using System.Reflection;
using Doss.Core.Domain.Settings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Doss.Core.Seedwork;

public static class Bootstrap
{
    public static void InitCore(this IServiceCollection service)
    {
        service.ConfigureMediatR();
        service.SetupValidators();
    }

    private static void ConfigureMediatR(this IServiceCollection service)
    {
        var assembly = typeof(Command).GetTypeInfo().Assembly;
        service.AddMediatR(assembly);
    }

    private static void SetupValidators(this IServiceCollection services)
    {
        FluentValidation.AssemblyScanner.FindValidatorsInAssemblyContaining<Command>()
            .ForEach(c =>
            {
                services.AddScoped(c.ValidatorType);
            });
    }
}