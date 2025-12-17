using Bsol.Business.Template.IntegrationTests.Mock.Service;
using Microsoft.AspNetCore.Mvc.Testing;
using NSubstitute;

namespace Bsol.Business.Template.IntegrationTests.Utils;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly WireMockSetup _wireMockSetup;

    public CustomWebApplicationFactory()
    {
        _wireMockSetup = new WireMockSetup();
        _wireMockSetup.AddConfiguration(PokeApiMockService.Configure);
        _wireMockSetup.ApplyConfigurations();
    }
    public HttpClient CreateClientWithMocks(Action<IServiceCollection> configureMocks)
    {
        var client = WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("Test");
            builder.UseSetting("PokeApiService:BaseUrl", _wireMockSetup.BaseUrl);

            builder.ConfigureServices(services =>
            {
            });

        }).CreateClient();
        client.BaseAddress = new Uri(_wireMockSetup.BaseUrl);
        return client;
    }
    public new void Dispose()
    {
        _wireMockSetup.Dispose();
        base.Dispose();
    }
}
