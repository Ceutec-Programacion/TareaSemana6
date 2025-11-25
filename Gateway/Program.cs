using Yarp.ReverseProxy;

var builder = WebApplication.CreateBuilder(args);

// Agregamos YARP leyendo la config desde appsettings.json
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy();

app.Run();