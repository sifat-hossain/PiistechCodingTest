using MediatR;
using Piistech.Ecommerce.Application;

namespace Piistect.Ecommerce.Application.Products.Commands;

public class ProductDeleteCommand : IRequest<PiistechEcommerceResponse>
{
    public Guid Id { get; set; }
}
