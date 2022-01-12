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
    public class ProductController : Controller
    {
        
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            
            this.mediator = mediator;
        }
        
        public IActionResult Index()
        {
            return View();
        }


        // Product CRUD
        [HttpPost]
        [Route("Product/Add")]
        public async Task<IActionResult> ProductAdd(ProductDto product)
        {
            var userId = int.Parse(User.FindFirst(u => u.Type == ClaimTypes.NameIdentifier).Value);
            await mediator.Send(new AddProductCommand(product, userId));
            return Ok();
            
        }
        [HttpGet]
        [Route("Product/Get")]
        public async Task<IActionResult> ProductGet()
        {
            return Ok(await mediator.Send(new GetProductListQuery()));
        }
        [HttpGet]
        [Route("Product/Get/{id}")]
        public async Task<IActionResult> ProductGetById()
        {
            return Ok(await mediator.Send(new GetProductByIdQuery()));
        }
        [HttpDelete]
        [Route("Product/Delete/{id}")]
        public async Task<IActionResult> ProductDelete([FromRoute] int id)
        {
        
            return Ok(await mediator.Send(new DeleteProductCommand(id,User)));
        }
        [HttpPost]
        [Route("Product/Update")]
        public async Task<IActionResult> ProductUpdate(int productId,ProductDto product)
        {
            
            return Ok(await mediator.Send(new UpdateProductCommand( productId, product,User)));
        }
    }
}
