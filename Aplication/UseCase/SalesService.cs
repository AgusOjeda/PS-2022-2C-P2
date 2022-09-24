using Application.Interfaces;
using Application.Interfaces.Carritos;
using Application.Interfaces.CarritosProductos;
using Application.Interfaces.Ordenes;
using Application.Interfaces.Products;
using Domain.Entities;
using Domain.Mappers;
#nullable disable
namespace Application.UseCase
{
    public class SalesService : ISalesService
    {
        private readonly IClienteService _customerService;
        private readonly IProductoService _productService;
        private readonly ICarritoService _carritoService;
        private readonly ICarritoProductoService _cartProductService;
        private readonly IOrdenService _ordenService;

        public SalesService(IClienteService customerService, IProductoService productService, ICarritoService carritoService, ICarritoProductoService cartProductService, IOrdenService ordenService)
        {
            _customerService = customerService;
            _productService = productService;
            _carritoService = carritoService;
            _cartProductService = cartProductService;
            _ordenService = ordenService;
        }
        public void AddSale()
        {
            //Console.Clear();
            //List<CarritoProducto> cartProducts = new List<CarritoProducto>();
            //string verificacion = "";
            //bool ordenCreatedSuccesfuly = false;
            //bool hasOldProducts = false;
            //var customer = _customerService.GetCustomerByDni();
            //if (customer == null)
            //{
            //    Console.WriteLine("El cliente no existe, registre un cliente nuevo");
            //    customer = _customerService.CreateCustomer().Result;
            //}
            //var cart = _carritoService.CreateCart(customer.ClienteId);
            //var lista = _productService.GetAllProducts().Result;
            //var opcion = "";
            //var cartProductsOwned = _cartProductService.GetAllCarritoProducts(cart.CarritoId);
            //if (cart.Nuevo == false)
            //{
            //    hasOldProducts = true;
            //    Console.WriteLine("El carrito ya posee los siguientes productos: ");
            //    Console.WriteLine("|{0,-41}|{1,-8}|{2,-11}|", "Nombre","Cantidad","Precio");
            //    foreach (var product in cartProductsOwned)
            //    {
            //        Console.WriteLine("|{0,-41}|{1,-8}|{2,-11:C}|", product.Producto.Nombre, product.Cantidad, product.Producto.Precio);
            //    }
            //    Console.WriteLine("Continuar agregando productos [V], Terminar venta [C]");
            //    opcion = Console.ReadLine();
            //}
            //opcion = "v";
            //do
            //{
            //    switch (opcion.ToUpper())
            //    {
            //        case "V":
            //            do
            //            {
            //                Console.Clear();
            //                Console.WriteLine("|{0,-4}|{1,-41}|{2,-11}|", "ID", "Nombre", "Precio");
            //                foreach (var item in lista)
            //                {
            //                    Console.WriteLine("|{0,-4}|{1,-41}|{2,-11:C}|", item.ProductoId, item.Nombre, item.Precio);
            //                }
            //                Console.WriteLine("Ingrese el ID del producto que desea agregar al carrito: ");
            //                int idProduct = Convert.ToInt32(Console.ReadLine());
            //                if (lista.Any(x => x.ProductoId == idProduct))
            //                {
            //                    Console.WriteLine("Ingrese la cantidad que desea agregar al carrito: ");
            //                    int cantidad = Convert.ToInt32(Console.ReadLine());
            //                    var newItem = new CarritoProducto { CarritoId = cart.CarritoId, ProductoId = idProduct, Cantidad = cantidad };
            //                    if (hasOldProducts)
            //                    {
            //                        var oldItem = cartProductsOwned.Where(x => x.Producto.ProductoId == idProduct).FirstOrDefault();
            //                        if (oldItem != null)
            //                        {
            //                            oldItem.Cantidad += newItem.Cantidad;
            //                            _cartProductService.UpdateProduct(oldItem);
            //                        }
            //                    }
            //                    else
            //                    {
            //                        _cartProductService.AddProductToCart(newItem);
            //                    }
            //                    Console.WriteLine("Desea agregar otro producto? (S/N)");
            //                    verificacion = Console.ReadLine();
            //                }
            //            } while (verificacion.ToUpper() == "S");
            //            opcion = "c";
            //            break;
            //        case "C":
            //            var total = GetTotalCart(cart.CarritoId);
            //            Console.WriteLine("El total del carrito es: {0}", total);
            //            Console.WriteLine("Terminar con la compra? [S] para confirmar, cualquier otra tecla para cancelar");
            //            var confirmacion = Console.ReadLine();
            //            if (confirmacion.ToUpper() == "S")
            //            {
            //                cart.Estado = false;
            //                _carritoService.ChangeState(cart);
            //                _ordenService.Crear(cart.CarritoId, total);
            //                Console.WriteLine("Compra finalizada. Presione una tecla para continuar");
            //                ordenCreatedSuccesfuly = true;
            //                break;
            //            }
            //            Console.WriteLine("Compra cancelada. Presione una tecla para volver al menu principal.");
            //            ordenCreatedSuccesfuly = true;
            //            break;
            //    }
            //}while(ordenCreatedSuccesfuly == false);

        }
        private decimal GetTotalCart(Guid cartId)
        {
            decimal total = 0;
            var products = _cartProductService.GetAllCarritoProducts(cartId);
            Console.WriteLine("Carrito: {0}", cartId);
            foreach (var item in products)
            {
                Console.WriteLine("##### Producto obtenido: Producto: {0}, cantidad: {1}, precio: {2}", item.Producto.Nombre, item.Cantidad, item.Producto.Precio);
                total += (item.Cantidad * item.Producto.Precio);
            }     
            return total;
        }
    }
}
