using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

        var config = builder.Build();
    })
    // .ConfigureServices((context, services) =>
    // {
    //     services
    //         .AddFunctionsInfra(context.Configuration)
    //         .AddEmailServices(context.Configuration)
    //         .AddDomain(context.Configuration)
    //         .AddNotificationService()
    //         .AddData(context.Configuration)
    //         .AddQueriesRepositories()
    //         .AddDomainRepositories()
    //         .AddEmailSender(context.Configuration)
    //         .AddLoggerAbstractImplementations(context.Configuration)
    //         .AddDb(context.Configuration)
    //         .AddTargetJobService(context.Configuration)
    //         .AddInfrastructure();

    //     services.AddDbContext<GurujaContext>(options =>
    //     {
    //         options.UseSqlServer(context.Configuration.GetConnectionString("GurujaDbSqlServer"));
    //     });
    // })
    .Build();

host.Run();
