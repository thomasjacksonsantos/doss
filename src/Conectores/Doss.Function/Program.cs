using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Doss.Function.Seedwork;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

        var config = builder.Build();
    })
    .ConfigureServices((context, services) => {
        services.InitIoC(context.Configuration);
    })
    .Build();

host.Run();