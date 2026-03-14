namespace Bsol.Business.Template.Api.Endpoints.Transaction.List;


public class ListTransactionResponse
{
    public List<Core.TransactionAggregate.Transaction> Transactions { get; set; }

    public ListTransactionResponse() { }

    public ListTransactionResponse(List<Core.TransactionAggregate.Transaction> transactions)
    {
        Transactions = transactions;
    }
}
