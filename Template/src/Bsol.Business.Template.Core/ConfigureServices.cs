using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Bsol.Business.Template.Core;

public static class ConfigureServices
{
    public static readonly string CoreAssembly = "CoreAssembly";
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
}
