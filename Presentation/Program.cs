using Application.Handlers;
using Application.Interfaces;
using Application.Interfaces.Carritos;
using Application.Interfaces.CarritosProductos;
using Application.Interfaces.Handlers;
using Application.Interfaces.Ordenes;
using Application.Interfaces.Products;
using Application.UseCase.Carritos;
using Application.UseCase.CarritosProductos;
using Application.UseCase.Customers;
using Application.UseCase.Ordenes;
using Application.UseCase.Products;
using Domain.Entities;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Querys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["DefaultConnection"];
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
// Service
builder.Services.AddScoped<DbContext, AppDbContext>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IProductoService, ProductoService>();
builder.Services.AddTransient<ICarritoService, CarritoService>();
builder.Services.AddTransient<ICarritoProductoService, CarritoProductoService>();
builder.Services.AddTransient<IOrdenService, OrdenService>();
// Command
builder.Services.AddTransient<ICommandHandler<Carrito>, CommandHandler<Carrito>>();
builder.Services.AddTransient<ICommandHandler<CarritoProducto>, CommandHandler<CarritoProducto>>();
builder.Services.AddTransient<ICommandHandler<Cliente>, CommandHandler<Cliente>>();
builder.Services.AddTransient<ICommandHandler<Producto>, CommandHandler<Producto>>();
builder.Services.AddTransient<ICommandHandler<Orden>, CommandHandler<Orden>>();
// Query
builder.Services.AddTransient<IClienteQuery, ClienteQuery>();
builder.Services.AddTransient<IProductoQuery, ProductQuery>();
builder.Services.AddTransient<ICarritoQuery, CarritoQuery>();
builder.Services.AddTransient<ICarritoProductoQuery, CarritoProductoQuery>();
builder.Services.AddTransient<IOrdenQuery, OrdenQuery>();
// Handler's
builder.Services.AddTransient<IHandlerProductToCart, ProductToCartHandler>();
builder.Services.AddTransient<IOrdenHandler, OrdenHandler>();
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
