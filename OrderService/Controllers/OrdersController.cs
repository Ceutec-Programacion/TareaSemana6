using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private static readonly List<Order> Orders = new()
    {
        new Order { Id = 1, CustomerId = 1, ProductId = 2, Quantity = 3 },
        new Order { Id = 2, CustomerId = 2, ProductId = 1, Quantity = 1 }
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
        if (order is null) return NotFound();

        return Ok(order);
    }
}
