using System.Net;
using System.Text.Json;
using Bsol.Business.Template.Api.Endpoints.Account.Get;
using Bsol.Business.Template.IntegrationTests.Data;
using Bsol.Business.Template.IntegrationTests.Utils;
using Bsol.Business.Template.SharedKernel.Interfaces;
using Shouldly;
using Xunit;

namespace Bsol.Business.Template.IntegrationTests.Api.Account;

public class GetAccountTest : BaseEfRepositoryTest, IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public GetAccountTest(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAccount_ByAccountNumber_ShouldReturnOk_WhenAccountExists()
    {
        // Arrange
        var seededAccounts = SeedAccountData.SeedAccounts();
        var targetAccount = seededAccounts.First();
        
        var httpClient = _factory.CreateClientWithMocks(services =>
        {
            var apiAccountRepository = GetAccountSeedRepository();
            apiAccountRepository.AddRangeAsync(seededAccounts).GetAwaiter().GetResult();
            
            services.AddTransient<IRepository<Core.AccountAggregate.Account>>(provider => apiAccountRepository);
        });

        // Act
        var response = await httpClient.GetAsync($"Bsol/v1/accounts/{targetAccount.AccountNumber}");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.ShouldBe(HttpStatusCode.OK);

        var responseContent = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var accountResponse = JsonSerializer.Deserialize<GetAccountResponse>(responseContent, options);

        accountResponse.ShouldNotBeNull();
        accountResponse.AccountNumber.ShouldBe(targetAccount.AccountNumber);
        accountResponse.Balance.ShouldBe(targetAccount.Balance);
    }

    [Fact]
    public async Task GetAccount_ByAccountId_ShouldReturnOk_WhenAccountExists()
    {
        // Arrange
        var seededAccounts = SeedAccountData.SeedAccounts();
        var targetAccount = seededAccounts.First();
        
        var httpClient = _factory.CreateClientWithMocks(services =>
        {
            var apiAccountRepository = GetAccountSeedRepository();
            apiAccountRepository.AddRangeAsync(seededAccounts).GetAwaiter().GetResult();
            
            services.AddTransient<IRepository<Core.AccountAggregate.Account>>(provider => apiAccountRepository);
        });

        // Act
        var response = await httpClient.GetAsync($"Bsol/v1/accounts/{targetAccount.Id}");

        // Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.ShouldBe(HttpStatusCode.OK);

        var responseContent = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var accountResponse = JsonSerializer.Deserialize<GetAccountResponse>(responseContent, options);

        accountResponse.ShouldNotBeNull();
        accountResponse.Id.ShouldBe(targetAccount.Id);
        accountResponse.AccountNumber.ShouldBe(targetAccount.AccountNumber);
    }

    [Fact]
    public async Task GetAccount_ShouldReturnProblem_WhenAccountDoesNotExist()
    {
        // Arrange
        var httpClient = _factory.CreateClientWithMocks(services =>
        {
            var apiAccountRepository = GetAccountSeedRepository();
            services.AddTransient<IRepository<Core.AccountAggregate.Account>>(provider => apiAccountRepository);
        });

        // Act
        var response = await httpClient.GetAsync("Bsol/v1/accounts/nonexistent");

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
    }
}
