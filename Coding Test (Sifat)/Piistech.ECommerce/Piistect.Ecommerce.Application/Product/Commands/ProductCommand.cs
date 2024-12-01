using System;

namespace Piistect.Ecommerce.Application.Product.Commands;

public class ProductCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal? Price { get; set; }
    public int Stock { get; set; }
}
