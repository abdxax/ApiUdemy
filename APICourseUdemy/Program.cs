using APICourseUdemy.Data;
using APICourseUdemy.Repstory;
using APICourseUdemy.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("myConnection"));
});
builder.Services.AddCors();
builder.Services.AddScoped<IUserRepstory, UserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(b=>b.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
