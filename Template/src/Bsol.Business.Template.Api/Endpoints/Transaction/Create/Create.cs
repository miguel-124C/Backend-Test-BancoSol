using Bsol.Business.Template.Core.UseCases.Transaction;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bsol.Business.Template.Api.Endpoints.Transaction.Create;

public class Create(IMediator _mediator) : Endpoint<CreateTransactionRequest, Results<Ok<CreateTransactionResponse>, NotFound, ProblemDetails>>
{

    public override void Configure()
    {
        Version(1);
        Post(CreateTransactionRequest.Route);
        AllowAnonymous();
    }

    public override async Task<Results<Ok<CreateTransactionResponse>, NotFound, ProblemDetails>> ExecuteAsync(CreateTransactionRequest request, CancellationToken ct)
    {


        var result = await _mediator.Send(new CreateTransactionCommand(request.SourceAccountNumber, request.DestinationAccountNumber, request.Amount), ct);

        if (!result.IsSuccess)
        {

            return new ProblemDetails
            {
                Detail = result.Errors.FirstOrDefault(),
                Status = StatusCodes.Status403Forbidden
            };
        }
        return TypedResults.Ok(new CreateTransactionResponse(result.Value.TransactionId, result.Value.VoucherCode));

    }

}
