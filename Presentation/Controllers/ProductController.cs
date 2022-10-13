using Application.Interfaces.Products;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CreateClienteRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProduct([FromQuery] ProductsQueryRequest request)
        {
            ICollection<ProductoResponse> products;
            if (!String.IsNullOrEmpty(request.Name))
            {
                products = await _productoService.GetProductsByName(request.Name, request.Sort);
            }
            else
            {
                products = await _productoService.GetAllProductsSort(request.Sort);
            }
            return StatusCode(200, products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            ProductoResponse product = await _productoService.GetProductById(id);
            if(product != null)
            {
                return StatusCode(200, product);
            }
            return StatusCode(404, new { Message = "Producto no encontrado" });
        }
    }
}
