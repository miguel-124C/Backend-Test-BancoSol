using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Bsol.Business.Template.Core.UseCases.Account.Create;

public record CreateAccountCommand(string OwnerName, string AccountNumber) : ICommand<Result<Guid>>
{
}
