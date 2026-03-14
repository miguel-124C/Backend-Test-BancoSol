using System.Net;
using System.Text.Json;
using Bsol.Business.Template.Api.Endpoints.Transaction.List;
using Bsol.Business.Template.IntegrationTests.Utils;
using Bsol.Business.Template.SharedKernel.Interfaces;
using Shouldly;
using Xunit;

namespace Bsol.Business.Template.IntegrationTests.Api.Transaction;

public class ListTransactionsTest : BaseEfRepositoryTest, IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public ListTransactionsTest(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task ListTransactions_ShouldReturnOk_WithTransactions()
    {
        // Arrange
        var sourceId = Guid.NewGuid();
        var destId = Guid.NewGuid();
        var transactions = new List<Core.TransactionAggregate.Transaction>
        {
            new Core.TransactionAggregate.Transaction(sourceId, destId, 100m, "V1"),
            new Core.TransactionAggregate.Transaction(destId, sourceId, 50m, "V2")
        };

        var httpClient = _factory.CreateClientWithMocks(services =>
        {
            var apiTransactionRepository = GetTransactionSeedRepository();
            apiTransactionRepository.AddRangeAsync(transactions).GetAwaiter().GetResult();
            
            services.AddTransient<IRepository<Core.TransactionAggregate.Transaction>>(provider => apiTransactionRepository);
        });

        // Act
        var response = await httpClient.GetAsync("Bsol/v1/transactions/");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.ShouldBe(HttpStatusCode.OK);

        var responseContent = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var listResponse = JsonSerializer.Deserialize<ListTransactionResponse>(responseContent, options);

        listResponse.ShouldNotBeNull();
        listResponse.Transactions.Count.ShouldBeGreaterThanOrEqualTo(2);
        listResponse.Transactions.Any(t => t.VoucherCode == "V1").ShouldBeTrue();
        listResponse.Transactions.Any(t => t.VoucherCode == "V2").ShouldBeTrue();
    }
}
