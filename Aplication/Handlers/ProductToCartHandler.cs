using Application.Interfaces;
using Application.Interfaces.Carritos;
using Application.Interfaces.CarritosProductos;
using Application.Interfaces.Products;
using Domain.Dtos.Request;
using Domain.Entities;

namespace Application.Handlers
{
    public class ProductToCartHandler : IHandlerProductToCart
    {
        private readonly IClienteService _customerService;
        private readonly IProductoService _productService;
        private readonly ICarritoService _carritoService;
        private readonly ICarritoProductoService _cartProductService;

        public ProductToCartHandler(IClienteService customerService, 
            IProductoService productService, 
            ICarritoService carritoService, 
            ICarritoProductoService cartProductService)
        {
            _customerService = customerService;
            _productService = productService;
            _carritoService = carritoService;
            _cartProductService = cartProductService;

        }
        public async Task<bool> HandleAdd(ProductToCarritoRequest request)
        {
            if (await _customerService.FindCustomer(request.ClientId) 
                && await _productService.Find(request.ProductId) 
                && request.Amount > 0)
            {
                var cart = await _carritoService.ActiveCart(request.ClientId);

                await _cartProductService.AddProductToCart(new CarritoProducto
                {
                    CarritoId = cart,
                    ProductoId = request.ProductId,
                    Cantidad = request.Amount
                });
                return true;
            }
            return false;
        }
        public async Task<bool> HandleUpdate(ProductToCarritoRequest request)
        {
            if (await _customerService.FindCustomer(request.ClientId) 
                && await _productService.Find(request.ProductId) 
                && request.Amount > 0)
            {
                var cart = await _carritoService.ActiveCart(request.ClientId);
                await _cartProductService.UpdateProduct(new CarritoProducto
                {
                    CarritoId = cart,
                    ProductoId = request.ProductId,
                    Cantidad = request.Amount
                });
                return true;
            }
            return false;
        }
        public async Task<bool> HandleDelete(int clientId, int productId)
        {
            if (await _customerService.FindCustomer(clientId))
            {
                var cart = await _carritoService.HasCartActive(clientId);
                if (cart != null)
                {
                    if (await _cartProductService.ValidateProductOnCart(productId, cart.CarritoId))
                    {
                        await _cartProductService.DeleteProduct(new CarritoProducto
                        {
                            CarritoId = cart.CarritoId,
                            ProductoId = productId
                        });
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
