using Bsol.Business.Template.Core.AccountAggregate;

namespace Bsol.Business.Template.IntegrationTests.Data;

public class SeedAccountData
{
    public static List<Account> SeedAccounts()
    {
        return [
            new Account("Owner 1", "1111111111") { Balance = 1000m },
            new Account("Owner 2", "2222222222") { Balance = 500m }
        ];
    }
}
