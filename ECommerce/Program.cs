using Application.Interfaces;
using Application.Interfaces.Carritos;
using Application.Interfaces.CarritosProductos;
using Application.Interfaces.Ordenes;
using Application.Interfaces.Products;
using Application.UseCase;
using Application.UseCase.Carritos;
using Application.UseCase.CarritosProductos;
using Application.UseCase.Customers;
using Application.UseCase.Ordenes;
using Application.UseCase.Products;
using Domain.Entities;
using ECommerce.Menu;
using Infraestructure.Command;
using Infraestructure.Persistence;
using Infraestructure.Querys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//CONFIG DEPENDENCY INJECTION
var builder = new ConfigurationBuilder();

var host = Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddDbContext<AppDbContext>();
            // Service
            services.AddScoped<DbContext, AppDbContext>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<ICarritoService, CarritoService> ();
            services.AddTransient<ICarritoProductoService, CarritoProductoService> ();
            services.AddTransient<IOrdenService, OrdenService>();
            services.AddTransient<ISalesService, SalesService>();
            // Command
            services.AddTransient<ICommandHandler<Carrito>, CommandHandler<Carrito>> ();
            services.AddTransient<ICommandHandler<CarritoProducto>, CommandHandler<CarritoProducto>> ();
            services.AddTransient<ICommandHandler<Cliente>, CommandHandler<Cliente>>();
            services.AddTransient<ICommandHandler<Producto>, CommandHandler<Producto>>();
            services.AddTransient<ICommandHandler<Orden>, CommandHandler<Orden>>(); 
            // Query
            services.AddTransient<IClienteQuery, ClienteQuery>();
            services.AddTransient<IProductoQuery, ProductQuery>();
            services.AddTransient<ICarritoQuery, CarritoQuery>();
            services.AddTransient<ICarritoProductoQuery, CarritoProductoQuery>();
            services.AddTransient<IOrdenQuery, OrdenQuery>();

        })
        .Build();
// SERVICE INSTANCE
var customerService = ActivatorUtilities.CreateInstance<ClienteService>(host.Services);
var productService = ActivatorUtilities.CreateInstance<ProductoService>(host.Services);
var carritoService = ActivatorUtilities.CreateInstance<CarritoService>(host.Services);
var carritoProductoService = ActivatorUtilities.CreateInstance<CarritoProductoService>(host.Services);
var ordenService = ActivatorUtilities.CreateInstance<OrdenService>(host.Services);
var salesService = ActivatorUtilities.CreateInstance<SalesService>(host.Services);

var mainMenu = new MainMenu(customerService, productService, carritoService, carritoProductoService, ordenService, salesService);
bool showMenu = true;
while (showMenu)
{
    showMenu = mainMenu.Show();
}
