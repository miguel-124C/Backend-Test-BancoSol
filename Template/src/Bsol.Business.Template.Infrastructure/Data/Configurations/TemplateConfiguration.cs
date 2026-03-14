using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bsol.Business.Template.Infrastructure.Data.Configurations;

public class TemplateConfiguration : IEntityTypeConfiguration<Core.TemplateAggregate.Template>
{
    public void Configure(EntityTypeBuilder<Core.TemplateAggregate.Template> builder)
    {
        builder.ToTable("Template");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).IsRequired(true);
        builder.Property(a => a.Name).HasMaxLength(50).IsRequired(true);

    }
}
