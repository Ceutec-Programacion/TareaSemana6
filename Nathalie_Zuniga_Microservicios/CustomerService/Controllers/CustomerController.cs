using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() => Ok(new[] { "Customer1", "Customer2" });

    [HttpGet("{id}")]
    public IActionResult GetById(int id) => Ok($"Customer {id}");
}
