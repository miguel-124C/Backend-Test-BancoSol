using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;


namespace Bsol.Business.Template.Core.UseCases.Template;

public record CreateTemplateCommand(string Name, int PokemonId) : ICommand<Result<Guid>>
{
}
