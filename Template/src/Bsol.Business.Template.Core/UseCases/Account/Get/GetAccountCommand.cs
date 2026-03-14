using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Bsol.Business.Template.Core.UseCases.Account.Get;

public record GetAccountCommand(Guid AccountId, string AccountNumber) : ICommand<Result<AccountAggregate.Account>>
{
}
