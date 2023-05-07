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
        private readonly ShopDbContext context;

        public ProductsController(ShopDbContext context)
        {
            this.context = context;
        }

        [HttpGet]                       // GET: ~/api/products
        //[HttpGet("all")]              // GET: ~/api/products/all
        //[HttpGet("/all-products")]    // GET: ~/all-products
        public IActionResult Get()
        {
            return Ok(context.Products.ToList());
        }

        // Details
        [HttpGet("details/{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0) return BadRequest();

            var product = context.Products.Find(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();

            context.Products.Add(product);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();

            context.Products.Update(product);
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var product = context.Products.Find(id);

            if (product == null) return NotFound();

            context.Products.Remove(product);
            context.SaveChanges();

            return Ok();
        }
    }
}
