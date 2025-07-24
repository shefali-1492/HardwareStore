
using BackOffice.API.Endpoints;
using BackOffice.Domain.Interfaces;
using BackOffice.Infrastructure.Repositories;
using BackOffice.Persistence;
using BackOffice.Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddApplicationServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
            "http://localhost:3000",       // React dev server
            "http://localhost:8080",       // Docker-exposed HTTP
            "https://localhost:8081"       // Docker-exposed HTTPS
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Register the extension method here
app.MapProductEndpoints();
app.UseCors("AllowFrontend");
app.Run();

