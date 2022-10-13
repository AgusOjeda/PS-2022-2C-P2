using Application.Interfaces.Carritos;
using Application.Interfaces.CarritosProductos;
using Application.Interfaces.Handlers;
using Application.Interfaces.Ordenes;
using Domain.Dtos.Response;


namespace Application.Handlers
{
    public class OrdenHandler : IOrdenHandler
    {
        private readonly ICarritoService _carritoService;
        private readonly ICarritoProductoService _cartProductService;
        private readonly IOrdenService _ordenService;

        public OrdenHandler(ICarritoService carritoService, ICarritoProductoService cartProductService, IOrdenService ordenService)
        {
            _carritoService = carritoService;
            _cartProductService = cartProductService;
            _ordenService = ordenService;
        }
        
        public async Task<bool> GenerateOrder(int clientId)
        {
            var cartId = await _carritoService.ActiveCart(clientId);
            var productsList = await _cartProductService.GetAllCarritoProducts(cartId);
            var orden = await _ordenService.Crear(cartId, productsList);
            var cartStatus = await _carritoService.ChangeState(cartId);
            if (orden && cartStatus)
                return true;
            else 
                return false;  
        }

        public async Task<BalancePerDayResponse> GenerateBalanceReport(string from, string to)
        {                 
            if (!String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to))
                return await _ordenService.BalanceReportFromTo(from, to);
            if (String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to))
                return await _ordenService.BalanceReportUntil(to);
            if (!String.IsNullOrEmpty(from) && String.IsNullOrEmpty(to))
                return await _ordenService.BalanceReportSince(from);
            return await _ordenService.BalanceReport();
        }
    }
}
