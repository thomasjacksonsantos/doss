
namespace Doss.Api;

/// <summary>
/// Class Program
/// </summary>
public class Program
{
    /// <summary>
    /// Main program
    /// </summary>
    /// <param name="args">arguments</param>
    public static void Main(string[] args)
        => CreateHostBuilder(args).Build().Run();

    /// <summary>
    /// Create host builder
    /// </summary>
    /// <param name="args">arguments</param>
    /// <returns>IHostBuilder</returns>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}

