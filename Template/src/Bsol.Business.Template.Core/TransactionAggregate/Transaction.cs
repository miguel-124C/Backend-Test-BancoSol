using Ardalis.GuardClauses;
using Bsol.Business.Template.SharedKernel.Audit;
using Bsol.Business.Template.SharedKernel.Interfaces;

namespace Bsol.Business.Template.Core.TransactionAggregate;

public class Transaction(Guid sourceAccountId, Guid destinationAccountId, decimal amount, string voucherCode)
    : AuditableEntity, IAggregateRoot
{
    public Guid SourceAccountId { get; set; } = Guard.Against.Default(sourceAccountId);
    public Guid DestinationAccountId { get; set; } = Guard.Against.Default(destinationAccountId);
    public decimal Amount { get; set; } = Guard.Against.NegativeOrZero(amount);
    public string VoucherCode { get; set; } = Guard.Against.NullOrEmpty(voucherCode);
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    //public Transaction(Guid id, Guid sourceAccountId, Guid destinationAccountId, decimal amount, string voucherCode)
    //    : this(sourceAccountId, destinationAccountId, amount, voucherCode)
    //{
    //    Id = id;
    //}
}
