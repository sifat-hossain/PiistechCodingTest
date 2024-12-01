using MediatR;
using Microsoft.EntityFrameworkCore;
using Piistech.Domain.Ecommerce.Ecommerce.Domain;
using Piistect.Ecommerce.Application.Products;

namespace Piistech.Ecommerce.Application.Products.Commands.Push
{
    public class ProductHandler(IEcommerceDbContext context) : IRequestHandler<ProductCommand,
        PiistechEcommerceResponse<ProductModel>>
    {
        private readonly IEcommerceDbContext _context = context;

        public async Task<PiistechEcommerceResponse<ProductModel>> Handle(ProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Product? product = await _context.Product
                    .Where(p => p.Id == command.Id && p.IsDeleted == false)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                if (product == null)
                {
                    product = new Product
                    {
                        Name = command.Name,
                        Description = command.Description,
                        Price = command.Price,
                        Stock = command.Stock,
                    };
                    await _context.Product.AddAsync(product, cancellationToken);
                }
                else
                {
                    product.Id = command.Id;
                    product.Name = command.Name;
                    product.Description = command.Description;
                    product.Price = command.Price;
                    product.Stock = command.Stock;
                    product.IsDeleted = command.IsDeleted;

                    _context.Product.Update(product);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return new PiistechEcommerceResponse<ProductModel>
                {
                    IsSuccessful = true,
                    Message = null,
                    Model = ProductModel.Create(product)
                };
            }
            catch (Exception ex)
            {
                return new PiistechEcommerceResponse<ProductModel>
                {
                    IsSuccessful = false,
                    Message = $"Failed to insert product with message: {ex.Message}, with inner exception:{ex.InnerException?.Message}"
                };
            }
        }
    }
}
