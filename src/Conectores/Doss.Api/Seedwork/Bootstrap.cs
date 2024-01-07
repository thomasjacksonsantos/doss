using Doss.Core.Seedwork;
using Doss.Infra.Seedwork;

namespace Doss.Api.Seedwork;

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
        services.InitCore();
        services.InitInfra(configuration);
    }

    private static string GetConnetion(string connection)
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