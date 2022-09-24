using Application.Interfaces.Ordenes;
using Application.Interfaces.Products;

namespace ECommerce.Menu
{
    public class SalesMenu
    {
        private readonly IOrdenService _ordenService;
        private readonly IProductoService _productService;
        public SalesMenu(IOrdenService ordenService, IProductoService productService)
        {
            _productService = productService;
            _ordenService = ordenService;
        }
        public bool Show()
        {
            Console.Clear();
            Console.WriteLine("REPORTES");
            Console.WriteLine("1. Ver ventas del dia");
            Console.WriteLine("2. Buscar ventas por producto");
            Console.WriteLine("7. Exit");
            Console.WriteLine("Enter your choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Listado de ventas");
                    var lista = _ordenService.GetAllOrden();
                    if(lista == null) return false;
                    foreach (var item in lista)
                    {
                        Console.WriteLine("Orden: " + item.OrdenId + " || Carrito: " + item.Carrito.CarritoId + "\nFecha: " + item.Fecha + " || Total: " + item.Total + "\nCliente: " + item.Carrito.Cliente.Nombre + " || Dni: " + item.Carrito.Cliente.DNI + "\n");
                        Console.WriteLine("Productos:");
                        Console.WriteLine("|{0,-41}|{1,-17}|{2,-11}|", "Nombre", "Marca", "Precio");
                        foreach (var produ in item.Carrito.CarritoProducto)
                        {
                            Console.WriteLine("|{0,-41}|{1,-17}|{2,-11:C}|", produ.Producto.Nombre, produ.Producto.Marca, produ.Producto.Precio);
                        }
                        Console.WriteLine("-------------------------------------------------------------------------");
                    }
                    Console.WriteLine("Presione un boton para volver atras");
                    Console.ReadKey();
                    return true;
                case 2:
                    Console.Clear();
                    Console.Write("\n Ingrese el id del producto a buscar: ");
                    int id = int.Parse(Console.ReadLine());
                    var product = _productService.GetProductById(id);
                    if(product == null)
                    {
                        Console.WriteLine("El producto ingresado no existe");
                        return false;
                    }
                    var listaByProduct = _ordenService.GetAllDataByProductId(id);
                    Console.WriteLine("Producto: {0}, Marca: {1}, Precio: {2} ",product.Result.Nombre, product.Result.Marca, product.Result.Precio);
                    if(!listaByProduct.Any(x => x.Carrito.CarritoProducto.Any()))
                        Console.WriteLine("No hay ventas registradas para ese producto.");
                    else
                    {
                        foreach (var item in listaByProduct)
                        {
                            if (item.Carrito.CarritoProducto.Any())
                            {
                                Console.WriteLine("Orden: " + item.OrdenId + " || Carrito: " + item.Carrito.CarritoId + "\nFecha: " + item.Fecha + " || Total: " + item.Total + "\nCliente: " + item.Carrito.Cliente.Nombre + " || Dni: " + item.Carrito.Cliente.DNI +"\n");
                            }
                        }
                    }
                    Console.WriteLine("Presione un boton para volver atras");
                    Console.ReadKey();
                    return true;
                case 7:
                    Environment.Exit(0);
                    return true;
                default:
                    Console.WriteLine("Opcion invalida");
                    return true;
            }
        }
    }
}
