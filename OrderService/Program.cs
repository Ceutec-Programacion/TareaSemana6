var builder = WebApplication.CreateBuilder(args);

// Servicios necesarios
builder.Services.AddControllers();

var app = builder.Build();

// Pipeline HTTP
app.MapControllers();

app.Run();
