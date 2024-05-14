using Microsoft.EntityFrameworkCore;
using UserWebApi.Data;
using UserWebApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IUserRepo,UserRepo>();
builder.Services.AddScoped<IUserRoleRepo,UserRoleRepo>();

builder.Services.AddDbContext<UserContext>(otp =>
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

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("string", typeof(string));
});
var app = builder.Build();

app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.UseRouting();
app.Run();
