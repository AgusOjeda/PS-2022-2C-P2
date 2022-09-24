using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public CustomerController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{dni}")]
        public IActionResult Get(string dni)
        {
            var customer = _clienteService.GetCustomerByDni(dni);
            return Ok(customer);
        }
    }
}
