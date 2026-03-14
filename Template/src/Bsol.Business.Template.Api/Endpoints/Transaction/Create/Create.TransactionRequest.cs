using System.ComponentModel.DataAnnotations;

namespace Bsol.Business.Template.Api.Endpoints.Transaction.Create;

public class CreateTransactionRequest
{
    public const string Route = "/transactions";

    [Required]
    public required string SourceAccountNumber { get; set; }
    [Required]
    public required string DestinationAccountNumber { get; set; }
    [Required]
    [Range(0, double.MaxValue)]
    public required decimal Amount { get; set; }
}
