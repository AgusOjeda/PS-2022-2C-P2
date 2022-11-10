using Application.Interfaces.Handlers;
using Domain.Dtos.Request;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenHandler _handler;

        public OrdenController(IOrdenHandler handler)
        {
            _handler = handler;
        }
        
        [HttpPost("{clientId}")]
        public async Task<IActionResult> Post(int clientId)
        {
            try
            {
                // 	Al generar la orden, no se comprueba que exista el carrito, entonces es posible generar ordenes sin productos
                var order = await _handler.GenerateOrder(clientId);
                return StatusCode(201, order);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    Message = "Error al crear la orden"
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> BalanceReport([FromQuery] BalanceReportRequest request)
        {   
            var balance = await _handler.GenerateBalanceReport(request.From, request.To);
            return StatusCode(200, balance);
        }
    }
}
