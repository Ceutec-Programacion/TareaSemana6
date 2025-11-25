using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers;

public record Product(int Id, string Name, decimal Price);

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products = new()
    {
        new Product(1, "Laptop", 1000),
        new Product(2, "Mouse", 20),
        new Product(3, "Teclado", 35)
    };

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
        => Ok(Products);

    [HttpGet("{id:int}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product is null) return NotFound();
        return Ok(product);
    }
}
