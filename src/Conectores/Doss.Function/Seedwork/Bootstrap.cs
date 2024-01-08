using System.Text.Json;
using Doss.Core.Domain.Settings;
using Doss.Core.Seedwork;
using Doss.Infra.Data;
using Doss.Infra.Seedwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Doss.Function.Seedwork;

/// <summary>
/// Class Bootstrap
/// </summary>
public static class Bootstrap
{
    /// <summary>
    /// InitIoC
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="configuration">configuration</param>
    public static void InitIoC(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));

        services.InitCore();
        services.InitInfra(configuration);

        services.AddDbContext<DossDbContext>(options =>
        {
            options.UseSqlServer(GetConnetion("ConnectionsString"));
        });
    }

    public static void EnvironmentVariable(this IServiceCollection services)
    {

    }

    static string GetConnetion(string connection)
    {
        var conn = Environment.GetEnvironmentVariable($"SQLAZURECONNSTR_{connection}");
        if (string.IsNullOrEmpty(conn))
        {
            conn = Environment.GetEnvironmentVariable($"ConnectionStrings:{connection}");
        }

        if (string.IsNullOrEmpty(conn))
        {
            conn = Environment.GetEnvironmentVariable(connection);
        }

        return conn ?? string.Empty;
    }
}