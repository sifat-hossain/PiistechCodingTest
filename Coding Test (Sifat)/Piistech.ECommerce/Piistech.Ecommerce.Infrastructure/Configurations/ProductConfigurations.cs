using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Piistech.Domain.Ecommerce.Ecommerce.Domain;

namespace Piistech.Ecommerce.Infrastructure.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product), p => p.IsTemporal());

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasDefaultValueSql("NEWID()");

        builder.Property(b => b.Name)
            .HasMaxLength(250);

        builder.Property(b => b.Description)
            .HasMaxLength(500);

        builder.Property(b => b.Price)
            .HasColumnType("decimal(11,2)");

        builder.Property(b => b.IsDeleted)
            .HasDefaultValue(false);
    }
}
