using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(new[] { "Order1", "Order2" });

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok($"Order {id}");
}
