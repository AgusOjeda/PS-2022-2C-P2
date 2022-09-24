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

namespace Application.UseCase.Sales
{
    public class SalesListService
    {
        private readonly IClienteService _customerService;
        private readonly IProductoService _productService;
        private readonly ICarritoService _carritoService;
        private readonly ICarritoProductoService _cartProductService;
        private readonly IOrdenService _ordenService;

        public SalesListService(IClienteService customerService, IProductoService productService, ICarritoService carritoService, ICarritoProductoService cartProductService, IOrdenService ordenService)
        {
            _customerService = customerService;
            _productService = productService;
            _carritoService = carritoService;
            _cartProductService = cartProductService;
            _ordenService = ordenService;
        }
        // TODO: Obtener el id del carrito en la orden y la fecha de la tabla ORDEN
        // TODO: Buscar el id y Obtener el customer de la tabla CARRITO
        // TODO: utilizar GetAllCarritoProducts de CarritoProductoService
        // para obtener la cantidad de cosas que se vendieron y su nombre y precio
        public void Report()
        {
            
        }
    }
}
