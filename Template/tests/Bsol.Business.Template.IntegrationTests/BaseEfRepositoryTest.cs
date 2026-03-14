using Bsol.Business.Template.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace Bsol.Business.Template.IntegrationTests;

public abstract class BaseEfRepositoryTest
{
    protected AppDbContext _dbContext;

    protected BaseEfRepositoryTest()
    {
        var options = CreateNewContextOptions();

        _dbContext = new AppDbContext(options);
    }

    protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        var builder = new DbContextOptionsBuilder<AppDbContext>();
        builder.UseInMemoryDatabase("TestDb")
            .UseInternalServiceProvider(serviceProvider);

        return builder.Options;

    }

    public EfRepository<Core.TemplateAggregate.Template> GetCategorySeedRepository() => new(_dbContext);
    public EfRepository<Core.AccountAggregate.Account> GetAccountSeedRepository() => new(_dbContext);
    public EfRepository<Core.TransactionAggregate.Transaction> GetTransactionSeedRepository() => new(_dbContext);
}
