var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

var orders = new List<dynamic>
{
    new { Id = 1, CustomerId = 1, ProductId = 2, Quantity = 3 },
    new { Id = 2, CustomerId = 2, ProductId = 1, Quantity = 1 },
    new { Id = 3, CustomerId = 3, ProductId = 3, Quantity = 2 }
};

app.MapGet("/orders", () =>
{
  return orders;
})
.WithName("GetOrders");

app.MapGet("/orders/{id:int}", (int id) =>
{
  var order = orders.FirstOrDefault(o => o.Id == id);
  return order is null ? Results.NotFound() : Results.Ok(order);
})
.WithName("GetOrderById");

app.Run();
