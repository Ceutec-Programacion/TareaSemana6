using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m },
        new Product { Id = 2, Name = "Mouse", Price = 25.50m }
    };

    [HttpGet]
    public IActionResult GetProducts() => Ok(Products);

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        return product != null ? Ok(product) : NotFound();
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}