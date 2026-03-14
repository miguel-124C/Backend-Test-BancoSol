using System.Transactions;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Bsol.Business.Template.Core.AccountAggregate.Specifications;

namespace Bsol.Business.Template.Core.UseCases.Transaction;

public class ListTransactionCommandHandler(
    SharedKernel.Interfaces.IRepository<TransactionAggregate.Transaction> _repository
    ) : ICommandHandler<ListTransactionCommand, Result<List<TransactionAggregate.Transaction>>>
{
    public async Task<Result<List<TransactionAggregate.Transaction>>> Handle(ListTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var transactions = await _repository.ListAsync(cancellationToken);
            return Result.Success(transactions);
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);
        }
    }
}
