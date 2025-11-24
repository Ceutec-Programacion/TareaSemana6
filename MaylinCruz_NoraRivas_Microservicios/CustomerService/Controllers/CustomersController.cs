using CustomerService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private static readonly List<Customer> Customers = new()
        {
            new Customer { Id = 1, Name = "Maylin Cruz", Email = "cruzmaylin157@gmail.com" },
            new Customer { Id = 2, Name = "Nora Rivas", Email = "nrivas25@gmail.com" }
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
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }
    }
}
