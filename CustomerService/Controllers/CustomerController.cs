using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private static readonly List<Customer> Customers = new()
    {
        new Customer { Id = 1, Name = "Juan Pérez", Email = "juan@email.com" },
        new Customer { Id = 2, Name = "María García", Email = "maria@email.com" }
    };

    [HttpGet]
    public IActionResult GetCustomers() => Ok(Customers);

    [HttpGet("{id}")]
    public IActionResult GetCustomer(int id)
    {
        var customer = Customers.FirstOrDefault(c => c.Id == id);
        return customer != null ? Ok(customer) : NotFound();
    }
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}