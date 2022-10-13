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
            var success = await _handler.GenerateOrder(clientId);
            if (success)
                return StatusCode(201, new
                {
                    Message = "Orden Creada con exito"
                });
            return StatusCode(400, new { Message = "Error al crear la orden" });
        }

        [HttpGet]
        public async Task<IActionResult> BalanceReport([FromQuery] BalanceReportRequest request)
        {   
            var balance = await _handler.GenerateBalanceReport(request.From, request.To);
            return StatusCode(200, balance);
        }
    }
}
