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
var customers = new List<Customer>
{
    new Customer { Id = 1, Name = "Juan Perez", Email = "juan@example.com" },
    new Customer { Id = 2, Name = "Maria Lopez", Email = "maria@example.com" },
    new Customer { Id = 3, Name = "Carlos Diaz", Email = "carlos@example.com" }
};

// GET /customers
app.MapGet("/customers", () => customers);

// GET /customers/{id}
app.MapGet("/customers/{id:int}", (int id) =>
{
    var customer = customers.FirstOrDefault(c => c.Id == id);
    return customer is not null ? Results.Ok(customer) : Results.NotFound();
});

app.Run();

record Customer
{
    public int Id { get; init; }
    public string Name { get; init; } = default!;
    public string Email { get; init; } = default!;
}