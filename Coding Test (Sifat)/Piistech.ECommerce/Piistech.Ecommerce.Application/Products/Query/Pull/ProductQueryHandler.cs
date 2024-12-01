using MediatR;
using Microsoft.EntityFrameworkCore;
using Piistech.Domain.Ecommerce.Ecommerce.Domain;
using Piistect.Ecommerce.Application.Products;

namespace Piistech.Ecommerce.Application.Products.Query.Pull
{
    public class ProductQueryHandler(IEcommerceDbContext context) : IRequestHandler<ProductQuery, List<ProductModel>>
    {
        private readonly IEcommerceDbContext _context = context;
        public async Task<List<ProductModel>> Handle(ProductQuery request, CancellationToken cancellationToken)
        {
            int skip = request.Skip ?? 0;
            int take = request.Take ?? 50;

            List<Product> products = await _context.Product
                .Skip(skip)
                .Take(take)
                .Where(x => !x.IsDeleted)
                .ToListAsync(cancellationToken: cancellationToken);

            return products.Select(p => ProductModel.Create(p)).ToList();
        }
    }
}
