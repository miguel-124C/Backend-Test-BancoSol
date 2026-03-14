using Bsol.Business.Template.Core.TransactionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bsol.Business.Template.Infrastructure.Data.Configurations;
internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).IsRequired(true);
        builder.Property(t => t.SourceAccountId).IsRequired(true);
        builder.Property(t => t.DestinationAccountId).IsRequired(true);
        builder.Property(t => t.Amount).HasDefaultValue(0).IsRequired(true);
        builder.Property(t => t.Timestamp).IsRequired(true);
        builder.Property(t => t.VoucherCode).IsRequired(true);
        builder.HasIndex(t => t.VoucherCode).IsUnique(true);
    }
}
