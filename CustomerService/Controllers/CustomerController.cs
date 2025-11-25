using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{

    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private static readonly List<Customer> Customers = new()
        {
            new Customer { Id = 1, Name = "Kang Taehyun" },
            new Customer { Id = 2, Name = "Choi Yeonjun" },
            new Customer { Id = 3, Name = "Choi Soobin" },
            new Customer { Id = 4, Name = "Choi Beomgyu" },
            new Customer { Id = 5, Name = "Huening Kai" }
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

    
}