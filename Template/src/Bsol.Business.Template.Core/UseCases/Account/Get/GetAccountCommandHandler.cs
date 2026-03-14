using Ardalis.Result;
using Ardalis.SharedKernel;
using Bsol.Business.Template.Core.AccountAggregate.Specifications;

namespace Bsol.Business.Template.Core.UseCases.Account.Get;

public class GetAccountCommandHandler(SharedKernel.Interfaces.IRepository<AccountAggregate.Account> _repository) : ICommandHandler<GetAccountCommand, Result<AccountAggregate.Account>>
{
    public async Task<Result<AccountAggregate.Account>> Handle(GetAccountCommand request, CancellationToken cancellationToken)
    {
        try
        {
            AccountByIdOrNumber spec;

            if (request.AccountId != Guid.Empty)
            {
                spec = new AccountByIdOrNumber(request.AccountId);
            }
            else if (!string.IsNullOrWhiteSpace(request.AccountNumber))
            {
                spec = new AccountByIdOrNumber(request.AccountNumber);
            }
            else
            {
                return Result.Invalid(new ValidationError("Either AccountId or AccountNumber must be provided."));
            }

            var account = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

            if (account == null)
            {
                return Result.NotFound("Account not found.");
            }

            return Result.Success(account);
        }
        catch (Exception ex)
        {
            return Result.Error(ex.Message);
        }
    }
}
