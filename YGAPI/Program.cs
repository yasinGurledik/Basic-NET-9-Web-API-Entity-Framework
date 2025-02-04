using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using YGAPI.Controllers.Data;//1. adým

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationVideoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();//2 adým
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
