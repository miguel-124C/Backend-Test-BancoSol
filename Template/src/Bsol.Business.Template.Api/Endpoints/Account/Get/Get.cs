using Bsol.Business.Template.Core.UseCases.Account;
using Bsol.Business.Template.Core.UseCases.Account.Get;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bsol.Business.Template.Api.Endpoints.Account.Get;

public class Get(IMediator _mediator) : Endpoint<GetAccountRequest, Results<Ok<GetAccountResponse>, NotFound, ProblemDetails>>
{

    public override void Configure()
    {
        Version(1);
        Get(GetAccountRequest.Route);
        AllowAnonymous();
    }

    public override async Task<Results<Ok<GetAccountResponse>, NotFound, ProblemDetails>> ExecuteAsync(GetAccountRequest request, CancellationToken ct)
    {
        Guid accountIdGuid = Guid.Empty;
        string accountNumber = string.Empty;

        if (Guid.TryParse(request.AccountId, out var parsedGuid))
        {
            accountIdGuid = parsedGuid;
        }
        else
        {
            accountNumber = request.AccountId;
        }

        var result = await _mediator.Send(new GetAccountCommand(accountIdGuid, accountNumber), ct);

        if (!result.IsSuccess)
        {

            return new ProblemDetails
            {
                Detail = string.Join("; ", result.Errors),
                Status = StatusCodes.Status400BadRequest
            };
        }
        return TypedResults.Ok(new GetAccountResponse(result.Value));

    }

}
