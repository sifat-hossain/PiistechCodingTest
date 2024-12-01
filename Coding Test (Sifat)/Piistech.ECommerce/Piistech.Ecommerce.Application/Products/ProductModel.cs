using Piistech.Domain.Ecommerce.Ecommerce.Domain;
using System.Linq.Expressions;

namespace Piistect.Ecommerce.Application.Products;

public class ProductModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal? Price { get; set; }
    public int Stock { get; set; }
    public bool IsDeleted { get; set; }

    public static Expression<Func<Product, ProductModel>> Projection
    {
        get
        {
            return entity => new ProductModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Stock = entity.Stock,
                IsDeleted = entity.IsDeleted
            };
        }
    }

    public static ProductModel Create(Product product)
    {
        return Projection.Compile().Invoke(product);
    }
}
