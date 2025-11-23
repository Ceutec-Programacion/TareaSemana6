using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private static readonly List<Customer> Customers = new()
        {
            new Customer { Id = 1, Name = "Juan Perez" },
            new Customer { Id = 2, Name = "Maria Lopez" },
            new Customer { Id = 3, Name = "Carlos Ruiz" }
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
            if (customer == null) return NotFound();
            return Ok(customer);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
