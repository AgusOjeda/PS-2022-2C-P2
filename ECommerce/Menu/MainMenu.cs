using Application.Interfaces;
using Application.Interfaces.Carritos;
using Application.Interfaces.CarritosProductos;
using Application.Interfaces.Ordenes;
using Application.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Menu
{
    public class MainMenu
    {
        private readonly IClienteService _customerService;
        private readonly IProductoService _productService;
        private readonly ICarritoService _carritoService;
        private readonly ICarritoProductoService _carritoProductoService;
        private readonly IOrdenService _ordenService;
        private readonly ISalesService _salesService;
        public MainMenu(IClienteService customerService, IProductoService productService, ICarritoService carritoService, ICarritoProductoService carritoProductoService, IOrdenService ordenService, ISalesService salesService)
        {
            _customerService = customerService;
            _productService = productService;
            _carritoService = carritoService;
            _carritoProductoService = carritoProductoService;
            _ordenService = ordenService;
            _salesService = salesService;
        }

        public bool Show()
        {
            Console.Clear();
            Console.WriteLine("SISTEMA DE GESTION ECOMMERCE");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Registrar Venta");
            Console.WriteLine("3. Reportes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Please enter your choice");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CustomerMenu customerMenu = new CustomerMenu(_customerService);
                    customerMenu.Show();  
                    return true;
                case "2":
                    _salesService.AddSale();
                    Console.ReadKey();
                    return true;
                case "3":
                    SalesMenu salesMenu = new SalesMenu(_ordenService, _productService);
                    salesMenu.Show();
                    return true;
                case "4":
                    Console.WriteLine("Gracias por usar la aplicacion.");
                    Environment.Exit(0);
                    return false;
                default:
                    Console.WriteLine("Opcion invalida");
                    return true;
            }
        }
    }
}
