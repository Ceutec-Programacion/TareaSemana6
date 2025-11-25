var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

var products = new List<dynamic>
{
    new { Id = 1, Name = "Laptop", Price = 1200 },
    new { Id = 2, Name = "Mouse", Price = 25 },
    new { Id = 3, Name = "Monitor", Price = 300 }
};

app.MapGet("/products", () =>
{
  return products;
})
.WithName("GetProducts");

app.MapGet("/products/{id:int}", (int id) =>
{
  var product = products.FirstOrDefault(p => p.Id == id);
  return product is null ? Results.NotFound() : Results.Ok(product);
})
.WithName("GetProductById");

app.Run();
