using MediatR;
using Microsoft.AspNetCore.Mvc;
using Piistech.Ecommerce.Application;
using Piistech.Ecommerce.Application.Products.Commands.Push;
using Piistech.Ecommerce.Application.Products.Query.Pull;
using Piistect.Ecommerce.Application.Products;
using Piistect.Ecommerce.Application.Products.Commands;

namespace Piistech.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<List<ProductModel>> Pull([FromQuery] ProductQuery request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<PiistechEcommerceResponse<ProductModel>> Push(ProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<PiistechEcommerceResponse> Delete(Guid id)
        {
            ProductDeleteCommand command = new ProductDeleteCommand
            {
                Id = id
            };
            return await _mediator.Send(command);
        }
    }
}
