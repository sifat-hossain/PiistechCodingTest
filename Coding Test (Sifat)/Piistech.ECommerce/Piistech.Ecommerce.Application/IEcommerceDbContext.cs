using Microsoft.EntityFrameworkCore;
using Piistech.Domain.Ecommerce.Ecommerce.Domain;

namespace Piistech.Ecommerce.Application;

public interface IEcommerceDbContext
{
    public DbSet<Product> Product { get; set; }
    public DbSet<User> User { get; set; }

    /// <summary>
    /// Saves the changes
    /// </summary>
    /// <returns>The number of state entries written to the database</returns>
    int SaveChanges();

    /// <summary>
    /// Saves the changes async
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>The number of state entries written to the database</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
