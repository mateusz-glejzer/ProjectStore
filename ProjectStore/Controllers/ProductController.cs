using Microsoft.AspNetCore.Mvc;
using ProjectStore.Models;
using ProjectStore.Services;
using System.Security.Claims;
using MediatR;
using ProjectStore.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectStore.Commands;

namespace ProjectStore.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {

        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {

            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductDto product)
        {
            var userId = int.Parse(User.FindFirst(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await mediator.Send(new AddProductCommand(product, userId));
            return Ok();

        }
        [HttpGet]
        public async Task<IActionResult> ProductGet()
        {
            await mediator.Send(new GetProductListQuery());
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ProductGetById(int id)
        {
            await mediator.Send(new GetProductByIdQuery(id));
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> ProductDelete([FromRoute] int id)
        {
            await mediator.Send(new DeleteProductCommand(id, User));
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> ProductUpdate(int productId,ProductDto product)
        {
            await mediator.Send(new UpdateProductCommand(productId, product, User));
            return Ok();
        }
    }
}
