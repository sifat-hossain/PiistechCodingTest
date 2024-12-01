using MediatR;
using Piistect.Ecommerce.Application.Products;

namespace Piistech.Ecommerce.Application.Products.Commands.Push;

public class ProductCommand : IRequest<PiistechEcommerceResponse<ProductModel>>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public bool IsDeleted { get; set; }
}
