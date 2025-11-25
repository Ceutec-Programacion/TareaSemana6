using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers;

public record Customer(int Id, string Name, string Email);

[ApiController]
[Route("customers")]
public class CustomersController : ControllerBase
{
    private static readonly List<Customer> Customers = new()
    {
        new Customer(1, "Juan Perez", "juan@example.com"),
        new Customer(2, "Ana Lopez", "ana@example.com"),
        new Customer(3, "Carlos Diaz", "carlos@example.com")
    };

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetAll()
        => Ok(Customers);

    [HttpGet("{id:int}")]
    public ActionResult<Customer> GetById(int id)
    {
        var customer = Customers.FirstOrDefault(c => c.Id == id);
        if (customer is null) return NotFound();
        return Ok(customer);
    }
}
