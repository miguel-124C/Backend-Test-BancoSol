using System.Data.Common;
using Bsol.Business.Template.SharedKernel.Interfaces;

namespace Bsol.Business.Template.Infrastructure.Data;

public abstract class QueryRepository<T>(DbConnection connection) : IQueryRepository<T> where T : class
{

}
