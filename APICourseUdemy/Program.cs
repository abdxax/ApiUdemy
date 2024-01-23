using APICourseUdemy.Data;
using APICourseUdemy.Interface;
using APICourseUdemy.Repstory;
using APICourseUdemy.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("myConnection"));
});
builder.Services.AddCors();
//Add Services
builder.Services.AddScoped<IUserRepstory, UserService>();
builder.Services.AddScoped<ITokenService,TokenService>();

//Authantion 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
        ValidateIssuer=false,
        ValidateAudience=false,
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(b=>b.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
