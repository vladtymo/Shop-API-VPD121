using BusinessLogic.Interfaces;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace shop_api_vpd121.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet]                       // GET: ~/api/products
        //[HttpGet("all")]              // GET: ~/api/products/all
        //[HttpGet("/all-products")]    // GET: ~/all-products
        public IActionResult Get()
        {
            return Ok(productsService.GetAll());
        }

        // Details
        [HttpGet("details/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(productsService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();

            productsService.Create(product);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();

            productsService.Edit(product);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            productsService.Delete(id);
            return Ok();
        }
    }
}
