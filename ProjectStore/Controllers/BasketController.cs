using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectStore.Models;
using System.Threading.Tasks;

namespace ProjectStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(ProductDto product)
        {
            
            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {

            return Ok();

        }

        
        [HttpPatch("delete/{id}")]
        public async Task<IActionResult> DeleteFromBasket(int id)
        {

            return Ok();

        }

        [HttpPatch("change/{id}")]
        public async Task<IActionResult> ChangeQuantityInBasket(int id)
        {

            return Ok();

        }




    }
}
