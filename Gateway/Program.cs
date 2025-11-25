using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromMemory(new[]
    {
        new RouteConfig
        {
            RouteId ="customer",
            ClusterId="customer-cluster",
            Match = new(){Path = "/customer/{**catch-all}"} 
        },
        new RouteConfig
        {
            RouteId ="order",
            ClusterId="order-cluster",
            Match =new(){Path = "/order/{**catch-all}"}
        },
        new RouteConfig
        {
            RouteId ="product",
            ClusterId="product-cluster",
            Match =new(){Path = "/product/{**catch-all}"}
        },

    },
    new[]
    {
        new ClusterConfig
        {
            ClusterId = "customer-cluster",
            Destinations = new Dictionary<string, DestinationConfig> 
            {
                {"d1", new DestinationConfig{ Address="http://customer-api:8080/api"} }
            },
        },
        new ClusterConfig
        {
            ClusterId = "order-cluster",
            Destinations = new Dictionary<string, DestinationConfig> 
            {
                {"d1", new DestinationConfig{ Address="http://order-api:8080/api"}}
            },
        },
        new ClusterConfig
        {
            ClusterId = "product-cluster",
            Destinations = new Dictionary<string, DestinationConfig> 
            {
                {"d1", new DestinationConfig{ Address="http://order-api:8080/api"} }
            },
        },
     
        });


var app = builder.Build();
app.MapGet("/health", () => Results.Ok(new { services = "Gateway", status = "Running" }));
app.MapReverseProxy();
app.Run();
