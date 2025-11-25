using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private static readonly List<Order> Orders = new()
    {
        new Order { Id = 1, CustomerId = 1, ProductId = 1, Quantity = 2 },
        new Order { Id = 2, CustomerId = 2, ProductId = 2, Quantity = 1 }
    };

    [HttpGet]
    public IActionResult GetOrders() => Ok(Orders);

    [HttpGet("{id}")]
    public IActionResult GetOrder(int id)
    {
        var order = Orders.FirstOrDefault(o => o.Id == id);
        return order != null ? Ok(order) : NotFound();
    }
}

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}