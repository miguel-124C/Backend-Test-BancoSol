using System.ComponentModel.DataAnnotations;

namespace Bsol.Business.Template.Api.Endpoints.Template;

public class CreateTemplateRequest
{
    public const string Route = "/Template";

    [Required]
    public required string Name { get; set; }
    public int PokemondId { get; set; }
}
