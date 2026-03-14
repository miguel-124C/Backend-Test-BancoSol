using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Bsol.Business.Template.Core.UseCases.Account.Create;

public class CreateAccountCommandHandler(SharedKernel.Interfaces.IRepository<AccountAggregate.Account> _repository) : ICommandHandler<CreateAccountCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        try
        {
            //var account = new AccountByOwnerName(request.ownerName);
            var account = new AccountAggregate.Account(request.OwnerName, request.AccountNumber);
            var result = await _repository.AddAsync(account, cancellationToken);
            return result.Id;
            
        }
        catch (Exception ex)
        {

            return Result.Error(ex.Message);
        }
    }
}
