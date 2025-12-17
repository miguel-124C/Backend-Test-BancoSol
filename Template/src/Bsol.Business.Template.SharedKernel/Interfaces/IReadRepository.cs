using Ardalis.Specification;

namespace Bsol.Business.Template.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
