using Yarp.ReverseProxy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromMemory(
        new[]
        {
            new Yarp.ReverseProxy.Configuration.RouteConfig
            {
                RouteId = "products",
                ClusterId = "productsCluster",
                Match = new Yarp.ReverseProxy.Configuration.RouteMatch
                {
                    Path = "/products/{**catch-all}"
                }
            },
            new Yarp.ReverseProxy.Configuration.RouteConfig
            {
                RouteId = "customers",
                ClusterId = "customersCluster",
                Match = new Yarp.ReverseProxy.Configuration.RouteMatch
                {
                    Path = "/customers/{**catch-all}"
                }
            },
            new Yarp.ReverseProxy.Configuration.RouteConfig
            {
                RouteId = "orders",
                ClusterId = "ordersCluster",
                Match = new Yarp.ReverseProxy.Configuration.RouteMatch
                {
                    Path = "/orders/{**catch-all}"
                }
            }
        },
        new[]
        {
            new Yarp.ReverseProxy.Configuration.ClusterConfig
            {
                ClusterId = "productsCluster",
                Destinations = new Dictionary<string, Yarp.ReverseProxy.Configuration.DestinationConfig>
                {
                    { "d1", new Yarp.ReverseProxy.Configuration.DestinationConfig { Address = "http://productservice:5001/" } }
                }
            },
            new Yarp.ReverseProxy.Configuration.ClusterConfig
            {
                ClusterId = "customersCluster",
                Destinations = new Dictionary<string, Yarp.ReverseProxy.Configuration.DestinationConfig>
                {
                    { "d1", new Yarp.ReverseProxy.Configuration.DestinationConfig { Address = "http://customerservice:5002/" } }
                }
            },
            new Yarp.ReverseProxy.Configuration.ClusterConfig
            {
                ClusterId = "ordersCluster",
                Destinations = new Dictionary<string, Yarp.ReverseProxy.Configuration.DestinationConfig>
                {
                    { "d1", new Yarp.ReverseProxy.Configuration.DestinationConfig { Address = "http://orderservice:5003/" } }
                }
            }
        }
    );

var app = builder.Build();

app.MapReverseProxy();

app.Run();
