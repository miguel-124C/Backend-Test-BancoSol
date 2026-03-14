using System.Transactions;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Bsol.Business.Template.Core.AccountAggregate.Specifications;

namespace Bsol.Business.Template.Core.UseCases.Transaction;

public class CreateTransactionCommandHandler(
    SharedKernel.Interfaces.IRepository<TransactionAggregate.Transaction> _repository,
    SharedKernel.Interfaces.IRepository<AccountAggregate.Account> _accountRepository
    ) : ICommandHandler<CreateTransactionCommand, Result<(Guid TransactionId, string VoucherCode)>>
{
    public async Task<Result<(Guid TransactionId, string VoucherCode)>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.SourceAccountNumber == request.DestinationAccountNumber)
                throw new Exception("You CANNOT transfer to the same account");

            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            var specSourceAccount = new AccountByIdOrNumber(request.SourceAccountNumber);
            var specDestinationAccount = new AccountByIdOrNumber(request.DestinationAccountNumber);

            var accountSource = await _accountRepository.FirstOrDefaultAsync(specSourceAccount, cancellationToken);
            var accountDestination = await _accountRepository.FirstOrDefaultAsync(specDestinationAccount, cancellationToken);

            if (accountSource == null || accountDestination == null)
                throw new Exception("Account not found");

            if (accountSource.Balance < request.Amount)
                throw new Exception("Insufficient balance");

            accountSource.Balance -= request.Amount;
            accountDestination.Balance += request.Amount;

            await _accountRepository.UpdateAsync(accountSource, cancellationToken);
            await _accountRepository.UpdateAsync(accountDestination, cancellationToken);

            var voucherCode = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            var transaction = new TransactionAggregate.Transaction(accountSource.Id, accountDestination.Id, request.Amount, voucherCode);
            var result = await _repository.AddAsync(transaction, cancellationToken);

            scope.Complete();
            return (result.Id, voucherCode);
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);
        }
    }
}
