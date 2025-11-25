using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configuración de YARP cargada desde memoria (similar a como tú lo estabas haciendo)
// Cumple con los requisitos del PDF: /api/products, /api/customers, /api/orders
builder.Services.AddReverseProxy()
    .LoadFromMemory(
        new[]
        {
            new RouteConfig()
            {
                RouteId = "products-route",
                ClusterId = "products-cluster",
                Match = new() { Path = "/api/products/{**catch-all}" }
            },
            new RouteConfig()
            {
                RouteId = "customers-route",
                ClusterId = "customers-cluster",
                Match = new() { Path = "/api/customers/{**catch-all}" }
            },
            new RouteConfig()
            {
                RouteId = "orders-route",
                ClusterId = "orders-cluster",
                Match = new() { Path = "/api/orders/{**catch-all}" }
            }
        },
        new[]
        {
            new ClusterConfig()
            {
                ClusterId = "products-cluster",
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    { "d1", new DestinationConfig { Address = "http://productservice:8080/" } }
                }
            },
            new ClusterConfig()
            {
                ClusterId = "customers-cluster",
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    { "d1", new DestinationConfig { Address = "http://customerservice:8080/" } }
                }
            },
            new ClusterConfig()
            {
                ClusterId = "orders-cluster",
                Destinations = new Dictionary<string, DestinationConfig>
                {
                    { "d1", new DestinationConfig { Address = "http://orderservice:8080/" } }
                }
            }
        }
    );

var app = builder.Build();

// Endpoint de prueba para ver si el Gateway está vivo
app.MapGet("/health", () => Results.Ok(new
{
    service = "Gateway",
    status = "Running"
}));

// Activar el proxy reverso
app.MapReverseProxy();

app.Run();
