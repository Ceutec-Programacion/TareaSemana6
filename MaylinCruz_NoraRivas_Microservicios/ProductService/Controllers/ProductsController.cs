using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private static readonly List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Monitor", Price = 1500m },
            new Product { Id = 2, Name = "Mouse inalambrico", Price = 295m },
            new Product { Id = 3, Name = "Parlantes", Price = 140m }
        };

        // GET: /api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(Products);
        }

        // GET: /api/products/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
