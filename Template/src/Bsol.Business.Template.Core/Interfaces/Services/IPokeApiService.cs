using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;


namespace Bsol.Business.Template.Core.Interfaces.Services;

public interface IPokeApiService
{
    Task<Result<EncounterData?>> EncounterMethod(int id, CancellationToken ct);
}
