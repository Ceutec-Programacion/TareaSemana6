using Microsoft.AspNetCore.Mvc;
using CustomerService.Models;

namespace CustomerService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private static readonly List<Customer> Customers = new()
    {
        new Customer { Id = 1, Name = "Ana López", Email = "ana@example.com" },
        new Customer { Id = 2, Name = "Juan Pérez", Email = "juan@example.com" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetAll()
    {
        return Ok(Customers);
    }

    [HttpGet("{id}")]
    public ActionResult<Customer> GetById(int id)
    {
        var customer = Customers.FirstOrDefault(c => c.Id == id);
        if (customer is null) return NotFound();

        return Ok(customer);
    }
}
