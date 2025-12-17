using FastEndpoints.Swagger;

namespace Bsol.Business.Template.Api.Extensions;

public static class ApiVersioningInjectionExtension
{
    public static IServiceCollection AddCustomApiVersioning(this IServiceCollection services)
    {
        services
       .SwaggerDocument(o =>
       {
           o.ShortSchemaNames = true;
           o.MaxEndpointVersion = 1;
           o.DocumentSettings = s =>
           {
               s.DocumentName = "Release 1.0";
               s.Title = "Template Api";
               s.Version = "v1.0";
           };
       });
        return services;
    }
}
