using Bsol.Business.Template.Api.Extensions;
using Bsol.Business.Template.Api.Health;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Bsol.Business.Template.Api;

public static class ConfigureServices
{
    private static readonly IEnumerable<string> Tags = new string[] { "example"};
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        string? TemplateUrl = configuration.GetValue<string>("Template.Options:Url");
        services.AddHealthChecks()
            .AddCheck("Example Health Check", new HttpHealthCheck(TemplateUrl), HealthStatus.Unhealthy, Tags.Where(row => row == "example"))
            ;

        services.AddApplicationInsightsTelemetry();
        services.Configure<TelemetryConfiguration>((o) =>
        {
            o.TelemetryInitializers.Add(new AppInsightsTelemetryInitializer());
        });
        return services;
    }
}
