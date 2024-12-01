using MediatR;
using Microsoft.EntityFrameworkCore;
using Piistech.Domain.Ecommerce.Ecommerce.Domain;
using Piistect.Ecommerce.Application.Products;
using Piistect.Ecommerce.Application.Products.Commands;

namespace Piistech.Ecommerce.Application.Products.Commands.Delete;

public class ProductDeleteHandler(IEcommerceDbContext context) : IRequestHandler<ProductDeleteCommand,
    PiistechEcommerceResponse>
{
    private readonly IEcommerceDbContext _context = context;

    public async Task<PiistechEcommerceResponse> Handle(ProductDeleteCommand command, CancellationToken cancellationToken)
    {
        try
        {
            Product? product = await _context.Product
                .Where(p => p.Id == command.Id && p.IsDeleted == false)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (product != null)
            {
                product.IsDeleted = true;
                _context.Product.Update(product);
                await _context.SaveChangesAsync(cancellationToken);

                return new PiistechEcommerceResponse<ProductModel>
                {
                    IsSuccessful = true,
                    Message = null,
                };
            }
            else
            {
                return new PiistechEcommerceResponse<ProductModel>
                {
                    IsSuccessful = true,
                    Message = "Product not found",
                };
            }
        }
        catch (Exception ex)
        {
            return new PiistechEcommerceResponse<ProductModel>
            {
                IsSuccessful = false,
                Message = $"Failed to Delete product with message: {ex.Message}, with inner exception:{ex.InnerException?.Message}"
            };
        }
    }
}
