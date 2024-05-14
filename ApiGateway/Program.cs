using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration).AddCacheManager(x=>x.WithDictionaryHandle());
builder.Services.AddCors(otp =>
{
    otp.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.



app.UseOcelot().Wait();

app.Run();
