using System.Net;
using System.Text;
using System.Text.Json;
using Bsol.Business.Template.Api.Endpoints.Transaction.Create;
using Bsol.Business.Template.IntegrationTests.Data;
using Bsol.Business.Template.IntegrationTests.Utils;
using Bsol.Business.Template.SharedKernel.Interfaces;
using Shouldly;
using Xunit;

namespace Bsol.Business.Template.IntegrationTests.Api.Transaction;

public class CreateTransactionTest : BaseEfRepositoryTest, IClassFixture<CustomWebApplicationFactory>
{
    private readonly string _url = CreateTransactionRequest.Route;
    private readonly CustomWebApplicationFactory _factory;

    public CreateTransactionTest(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task CreateTransaction_ShouldReturnOk_WhenRequestIsValid()
    {
        // Arrange
        var requestBody = new CreateTransactionRequest
        {
            SourceAccountNumber = "1111111111",
            DestinationAccountNumber = "2222222222",
            Amount = 100m
        };

        var httpClient = _factory.CreateClientWithMocks(services =>
        {
            var apiAccountRepository = GetAccountSeedRepository();
            apiAccountRepository.AddRangeAsync(SeedAccountData.SeedAccounts());
            apiAccountRepository.SaveChangesAsync();
            
            services.AddTransient<IRepository<Core.AccountAggregate.Account>>(provider => apiAccountRepository);
            
            var apiTransactionRepository = GetTransactionSeedRepository();
            services.AddTransient<IRepository<Core.TransactionAggregate.Transaction>>(provider => apiTransactionRepository);
        });

        var jsonData = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        // Act
        var response = await httpClient.PostAsync($"Bsol/v1{_url}", content, default);

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.ShouldBe(HttpStatusCode.OK);

        var responseContent = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var transactionResponse = JsonSerializer.Deserialize<CreateTransactionResponse>(responseContent, options);

        transactionResponse.ShouldNotBeNull();
        transactionResponse.TransactionId.ShouldNotBe(Guid.Empty);
        transactionResponse.VoucherCode.ShouldNotBeNullOrEmpty();
    }
}
