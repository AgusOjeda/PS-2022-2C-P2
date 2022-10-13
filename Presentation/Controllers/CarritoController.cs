using Application.Interfaces;
using Domain.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly IHandlerProductToCart _handler;

        public CarritoController(IHandlerProductToCart handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductToCarritoRequest request)
        {
            var success = await _handler.HandleAdd(request);
            if (success)
            {
                return StatusCode(201, new
                {
                    Message = "Producto agregado al carrito"
                });
            }
            return StatusCode(400, new
            {
                Message = "No se pudo agregar el producto al carrito"
            });
        }
        [HttpPut]
        public async Task<IActionResult> Edit(ProductToCarritoRequest request)
        {
            var success = await _handler.HandleUpdate(request);
            if (success)
            {
                return StatusCode(200, new
                {
                    Message = "Producto actualizado"
                });
            }
            return StatusCode(400, new
            {
                Message = "No se pudo actualizar el producto"
            });
        }
        [HttpDelete("{clientId}/{productId}")]
        public async Task<IActionResult> Delete(int clientId, int productId)
        {
            var success = await _handler.HandleDelete(clientId, productId);
            if (success)
            {
                return StatusCode(200, new
                {
                    Message = "Producto eliminado con exito"
                });
            }
            return StatusCode(400, new
            {
                Message = "No se pudo eliminar el producto"
            });
        }
    }
}
