using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers;

public record Order(int Id, int CustomerId, decimal Total);

[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    private static readonly List<Order> Orders = new()
    {
        new Order(1, 1, 1050),
        new Order(2, 2, 200),
        new Order(3, 1, 35)
    };

    [HttpGet]
    public ActionResult<IEnumerable<Order>> GetAll()
        => Ok(Orders);

    [HttpGet("{id:int}")]
    public ActionResult<Order> GetById(int id)
    {
        var order = Orders.FirstOrDefault(o => o.Id == id);
        if (order is null) return NotFound();
        return Ok(order);
    }
}
