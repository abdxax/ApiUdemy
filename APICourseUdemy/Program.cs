using APICourseUdemy.Data;
using APICourseUdemy.Extension;
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
builder.Services.ApplicationService(builder.Configuration);

//Authantion 
builder.Services.AuthenticationServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(b=>b.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
