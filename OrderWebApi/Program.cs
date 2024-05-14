using Microsoft.EntityFrameworkCore;
using OrderWebApi.Data;
using OrderWebApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("string", typeof(string));
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IOrderRepo,OrderRepo>();
builder.Services.AddScoped<IOrderDetailRepo,OrderDetailRepo>();
builder.Services.AddDbContext<OrderContext>(otp =>
{
    otp.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddCors(otp =>
{
    otp.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});
var app = builder.Build();


app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseRouting();
app.Run();
