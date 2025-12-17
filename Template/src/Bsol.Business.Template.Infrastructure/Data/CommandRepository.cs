using System.Diagnostics.CodeAnalysis;

namespace Bsol.Business.Template.Infrastructure.Data;

[ExcludeFromCodeCoverage]
public class CommandRepository<T>(AppDbContext dbContext) : CommandBaseRepository<T>(dbContext) where T : class
{
    private readonly AppDbContext _dbContext = dbContext;
}
