using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Bsol.Business.Template.Core.AccountAggregate;

namespace Bsol.Business.Template.Infrastructure.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Account");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).IsRequired(true);
        builder.Property(a => a.OwnerName).HasMaxLength(50).IsRequired(true);
        builder.Property(a => a.AccountNumber).HasMaxLength(50).IsRequired(true);
        builder.HasIndex(a => a.AccountNumber).IsUnique(true);
        builder.Property(a => a.Balance).IsRequired(true);
    }
}
