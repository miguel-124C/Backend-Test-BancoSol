using WireMock.Server;

namespace Bsol.Business.Template.IntegrationTests.Mock.Service;

public class PokeApiMockService
{
    public static void Configure(WireMockServer server)
    {
        server
            .Given(
                WireMock.RequestBuilders.Request.Create()
                    .WithPath("/api/v2/encounter-method/1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock.ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(@"
                    { ""id"": 1,
                      ""name"": ""walk"",
                      ""names"": [
                        {
                            ""language"": {
                                ""name"": ""de"",
                                ""url"": ""https://pokeapi.co/api/v2/language/6/""
                            },
                            ""name"": ""Im hohen Gras oder in einer Höhle laufen""
                        },
                        {
                            ""language"": {
                                ""name"": ""en"",
                                ""url"": ""https://pokeapi.co/api/v2/language/9/""
                            },
                            ""name"": ""Walking in tall grass or a cave""
                        },
                        {
                            ""language"": {
                                ""name"": ""fr"",
                                ""url"": ""https://pokeapi.co/api/v2/language/5/""
                            },
                            ""name"": ""En marchant dans les herbes hautes ou une grotte""
                        }
                    ],
                      ""order"": 1}")
            );
    }
}
