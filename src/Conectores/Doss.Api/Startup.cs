
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Doss.Api.Seedwork;
using Doss.Core.Domain.Settings;
using Microsoft.IdentityModel.Logging;
using NSwag;
using NSwag.Generation.Processors.Security;
using NSwag.AspNetCore;
using Doss.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Doss.Api;

/// <summary>
/// Class Startup
/// </summary>
public class Startup
{
    private const string CorsGlobalPolicyName = "CorsGlobalPolicy";

    /// <summary>
    /// Costructor Startup
    /// </summary>
    /// <param name="configuration">Configuration</param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    /// Configuration
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="services">Services</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            });

        services.AddDbContext<DossDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionsString")));

        services.AddOpenApiDocument(document =>
        {
            document.PostProcess = doc =>
            {
                doc.Info = new OpenApiInfo
                {
                    Title = "Doss Api",
                    Version = "V1",
                    Description = "Api Doss",
                    Contact = new OpenApiContact
                    {
                        Name = "Thomas Jackson",
                        Url = "https://www.linkedin.com/in/thomasjacksonsantos/"
                    }
                };
            };

            document.AddSecurity("bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.OAuth2,
                Description = "B2C authentication",
                Flow = OpenApiOAuth2Flow.Implicit,
                Flows = new OpenApiOAuthFlows()
                {
                    Implicit = new OpenApiOAuthFlow()
                    {
                        Scopes = new Dictionary<string, string>
                            {
                                    { $"{Configuration.GetSection("AzureAdB2C:Scopes:Task.Read").Value}", "Write access to the API" },
                                    { $"{Configuration.GetSection("AzureAdB2C:Scopes:Task.Write").Value}", "Read access to the API"},
                            },
                        AuthorizationUrl = $"{Configuration.GetSection("AzureAdB2C:AuthorizationUrl").Value}",
                        TokenUrl = $"{Configuration.GetSection("AzureAdB2C:TokenUrl").Value}",
                    },
                }
            });

            document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));
        });

        services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

        services.AddSingleton(service =>
        {
            var settings = service.GetService<Microsoft.Extensions.Options.IOptions<AppSettings>>()!.Value;
            return settings;
        });

        services.InitIoC();

        services.AddCors(options =>
        {
            options.AddPolicy(CorsGlobalPolicyName, builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
            });
        });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(options =>
                {
                    Configuration.Bind("AzureAdB2C", options);
                    options.TokenValidationParameters.NameClaimType = "name";
                },
                options =>
                {
                    Configuration.Bind("AzureAdB2C", options);
                });

        services.AddHttpClient(Configuration.GetSection("AppSettings:Cep:ServiceName").Value!, c => c.BaseAddress = new Uri(Configuration.GetSection("AppSettings:Cep:Url").Value!));
    }

    /// <summary>
    /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app">app</param>
    /// <param name="env">env</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            IdentityModelEventSource.ShowPII = true;
        }
        app.UseDeveloperExceptionPage();
        app.UseOpenApi();
        app.UseSwaggerUi3(settings =>
        {
            settings.OAuth2Client = new OAuth2ClientSettings
            {
                ClientId = Configuration.GetSection("Swagger:AzureB2CClientId").Value,
                AppName = "swagger-ui-client"
            };
        });
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Doss Api V1"));
        app.UseReDoc(options =>
        {
            options.Path = "/redoc";
        });

        app.UseCors(CorsGlobalPolicyName);

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    }
}
