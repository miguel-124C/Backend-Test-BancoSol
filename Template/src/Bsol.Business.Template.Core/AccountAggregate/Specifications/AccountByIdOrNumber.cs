using Ardalis.Specification;

namespace Bsol.Business.Template.Core.AccountAggregate.Specifications;

public class AccountByIdOrNumber : Specification<Account>, ISingleResultSpecification<Account>
{
    public AccountByIdOrNumber(Guid accountId)
    {
        Query.Where(account => account.Id == accountId);
    }

    public AccountByIdOrNumber(string accountNumber)
    {
        Query.Where(account => account.AccountNumber == accountNumber);
    }
}
