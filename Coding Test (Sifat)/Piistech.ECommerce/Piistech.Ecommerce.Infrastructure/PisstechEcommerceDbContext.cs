using Microsoft.EntityFrameworkCore;
using Piistech.Domain.Ecommerce.Ecommerce.Domain;
using Piistech.Ecommerce.Application;

namespace Piistech.Ecommerce.Infrastructure;

public class PisstechEcommerceDbContext(DbContextOptions options) : DbContext(options), IEcommerceDbContext
{
    public DbSet<Product> Product { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PisstechEcommerceDbContext).Assembly);

        modelBuilder.Entity<Product>()
           .Property(p => p.Price)
           .HasPrecision(11, 2);
    }
}
