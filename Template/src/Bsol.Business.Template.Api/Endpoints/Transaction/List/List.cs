using Bsol.Business.Template.Core.UseCases.Transaction;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bsol.Business.Template.Api.Endpoints.Transaction.List;

public class List(IMediator _mediator) : EndpointWithoutRequest<Results<Ok<ListTransactionResponse>, NotFound, ProblemDetails>>
{

    public override void Configure()
    {
        Version(1);
        Get("/transactions/");
        AllowAnonymous();
    }

    public override async Task<Results<Ok<ListTransactionResponse>, NotFound, ProblemDetails>> ExecuteAsync(CancellationToken ct)
    {
        var result = await _mediator.Send(new ListTransactionCommand(), ct);

        if (!result.IsSuccess)
        {
            return new ProblemDetails
            {
                Detail = result.Errors.FirstOrDefault(),
                Status = StatusCodes.Status403Forbidden
            };
        }
        return TypedResults.Ok(new ListTransactionResponse(result.Value));

    }

}
