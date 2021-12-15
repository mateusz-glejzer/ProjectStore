using Microsoft.AspNetCore.Mvc;
using ProjectStore.Models;
using ProjectStore.Services;

namespace ProjectStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }


        // Product CRUD
        [HttpPost]
        [Route("{controller}/Product/Add")]
        public IActionResult ProductAdd(ProductDto product)
        {
            string message = service.ProductAdd(product);
            return Created("", message);
        }
        [HttpGet]
        [Route("{controller}/Product/Get")]
        public IActionResult ProductGet()
        {
            return Ok(service.ProductGet());
        }
        [HttpDelete]
        [Route("{controller}/Product/Delete/{id}")]
        public IActionResult ProductDelete([FromRoute] int id)
        {
            string message = service.ProductDelete(id);
            return Ok(message);
        }
        [HttpPost]
        [Route("{controller}/Product/Update")]
        public IActionResult ProductUpdate(ProductDto product)
        {
            string message = service.ProductUpdate(product);
            return Ok(message);
        }
    }
}
