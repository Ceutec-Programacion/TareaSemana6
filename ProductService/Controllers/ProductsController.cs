using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000 },
            new Product { Id = 2, Name = "Mouse", Price = 25 },
            new Product { Id = 3, Name = "Keyboard", Price = 45 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
