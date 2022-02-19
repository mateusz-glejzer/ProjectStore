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

        [HttpPatch]
        public async Task<IActionResult> DeleteFromBasket(int id)
        {

            return Ok();

        }

        [HttpPatch]
        public async Task<IActionResult> ChangeQuantityInBasket(int id)
        {

            return Ok();

        }




    }
}
