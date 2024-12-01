using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Piistech.Domain.Ecommerce.Ecommerce.Domain;

namespace Piistech.Ecommerce.Infrastructure.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");

            builder.Property(b => b.Email)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(b => b.Password)
                .IsRequired();

            builder.Property(b => b.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
