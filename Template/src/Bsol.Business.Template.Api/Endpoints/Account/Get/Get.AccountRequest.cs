using FastEndpoints;

namespace Bsol.Business.Template.Api.Endpoints.Account.Get;

public class GetAccountRequest
{
    public const string Route = "/accounts/{AccountId}";

    public string AccountId { get; set; } = string.Empty;
}
