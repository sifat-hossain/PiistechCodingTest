using MediatR;
using Piistect.Ecommerce.Application.Products;

namespace Piistech.Ecommerce.Application.Products.Query.Pull;

public class ProductQuery : IRequest<List<ProductModel>>
{
    public int? Skip { get; set; }
    public int? Take { get; set; }
}
