using Ardalis.GuardClauses;
using Bsol.Business.Template.SharedKernel.Audit;
using Bsol.Business.Template.SharedKernel.Interfaces;

namespace Bsol.Business.Template.Core.AccountAggregate;

public class Account(string ownerName, string accountNumber) : AuditableEntity, IAggregateRoot
{
    public string OwnerName { get; set; } = Guard.Against.NullOrEmpty(ownerName);
    public string AccountNumber { get; set; } = Guard.Against.NullOrEmpty(accountNumber);
    public decimal Balance { get; set; } = 0;
    public DateTime UpdatedAt { get; set; }

    //public Account(Guid id, string accountNumber) : this(accountNumber)
    //{
    //    Id = id;
    //}
}
