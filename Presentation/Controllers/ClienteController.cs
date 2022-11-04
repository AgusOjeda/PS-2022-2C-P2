using Application.Interfaces;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        
        [HttpPost(Name = "CreateCliente")]
        [ProducesResponseType(typeof(CreateClienteRequest), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]        
        public async Task<IActionResult> CreateCustomers([FromBody] CreateClienteRequest createClienteRequest)
        {
            try
            {
                CreateClienteResponse result = await _clienteService.CreateCustomer(createClienteRequest);
                if(result.NewUser)
                    return StatusCode(201, result.Client);
                else
                {
                    return StatusCode(409, result.Client);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
        
    }
}
