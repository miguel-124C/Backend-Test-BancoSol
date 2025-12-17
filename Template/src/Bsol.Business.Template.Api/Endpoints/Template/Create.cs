using Bsol.Business.Template.Core.UseCases.Template;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Bsol.Business.Template.Api.Endpoints.Template;

public class Create(IMediator _mediator) : Endpoint<CreateTemplateRequest, Results<Ok<CreateTemplateResponse>, NotFound, ProblemDetails>>
{

    public override void Configure()
    {
        Version(1);
        Post(CreateTemplateRequest.Route);
        AllowAnonymous();
    }

    public override async Task<Results<Ok<CreateTemplateResponse>, NotFound, ProblemDetails>> ExecuteAsync(CreateTemplateRequest request, CancellationToken ct)
    {


        var result = await _mediator.Send(new CreateTemplateCommand(request.Name, request.PokemondId), ct);

        if (!result.IsSuccess)
        {

            return new ProblemDetails
            {
                Detail = result.Errors.FirstOrDefault(),
                Status = StatusCodes.Status403Forbidden
            };
        }
        return TypedResults.Ok(new CreateTemplateResponse(result.Value));

    }

}
