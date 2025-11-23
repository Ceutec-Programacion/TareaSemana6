using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly List<Order> Orders = new()
        {
            new Order { Id = 1, ProductId = 1, Quantity = 2 },
            new Order { Id = 2, ProductId = 2, Quantity = 1 },
            new Order { Id = 3, ProductId = 3, Quantity = 5 }
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
            if (order == null) return NotFound();
            return Ok(order);
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
