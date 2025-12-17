using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace Bsol.Business.Template.SharedKernel;

[ExcludeFromCodeCoverage]
public abstract class DomainEventBase : INotification
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
