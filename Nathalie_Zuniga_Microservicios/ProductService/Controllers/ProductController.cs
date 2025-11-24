using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(new[] { "Product1", "Product2" });

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok($"Product {id}");
}
