var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.UseHttpsRedirection();

var customers = new List<dynamic>
{
    new { Id = 1, Name = "John Doe" },
    new { Id = 2, Name = "Jane Smith" },
    new { Id = 3, Name = "Jorge Siguenza" }
};

app.MapGet("/customers", () =>
{
  return customers;
})
.WithName("GetCustomers");

app.MapGet("/customers/{id:int}", (int id) =>
{
  var customer = customers.FirstOrDefault(c => c.Id == id);
  return customer is null ? Results.NotFound() : Results.Ok(customer);
})
.WithName("GetCustomerById");

app.Run();
