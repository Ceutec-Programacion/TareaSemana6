using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private static readonly List<Order> Orders = new()
        {
            new Order { Id = 1, CustomerId = 1, Date = DateTime.UtcNow.AddDays(-2), Total = 120m },
            new Order { Id = 2, CustomerId = 2, Date = DateTime.UtcNow.AddDays(-1), Total = 250m }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAll()
        {
            return Ok(Orders);
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetById(int id)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }
    }
}
