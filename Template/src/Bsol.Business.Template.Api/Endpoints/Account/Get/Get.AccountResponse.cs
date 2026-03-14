namespace Bsol.Business.Template.Api.Endpoints.Account.Get;

public class GetAccountResponse
{
    public Guid Id { get; set; }
    public string OwnerName { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }

    public GetAccountResponse() { }

    public GetAccountResponse(Core.AccountAggregate.Account account)
    {
        Id = account.Id;
        OwnerName = account.OwnerName;
        AccountNumber = account.AccountNumber;
        Balance = account.Balance;
    }
}
