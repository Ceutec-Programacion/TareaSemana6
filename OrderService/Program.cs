var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Datos en memoria
var orders = new List<Order>
{
    new Order { Id = 1, CustomerId = 1, Total = 100 },
    new Order { Id = 2, CustomerId = 2, Total = 250 },
    new Order { Id = 3, CustomerId = 1, Total = 75 }
};

// GET /orders
app.MapGet("/orders", () => orders);

// GET /orders/{id}
app.MapGet("/orders/{id:int}", (int id) =>
{
    var order = orders.FirstOrDefault(o => o.Id == id);
    return order is not null ? Results.Ok(order) : Results.NotFound();
});

app.Run();

record Order
{
    public int Id { get; init; }
    public int CustomerId { get; init; }
    public decimal Total { get; init; }
}