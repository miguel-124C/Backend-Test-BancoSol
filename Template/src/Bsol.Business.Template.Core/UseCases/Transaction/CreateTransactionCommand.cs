using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Bsol.Business.Template.Core.UseCases.Transaction;

public record CreateTransactionCommand(string SourceAccountNumber, string DestinationAccountNumber, decimal Amount) : ICommand<Result<(Guid TransactionId, string VoucherCode)>>
{
}
