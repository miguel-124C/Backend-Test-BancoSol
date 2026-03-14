using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Bsol.Business.Template.Core.UseCases.Transaction;

public record ListTransactionCommand() : ICommand<Result<List<TransactionAggregate.Transaction>>>
{
}
