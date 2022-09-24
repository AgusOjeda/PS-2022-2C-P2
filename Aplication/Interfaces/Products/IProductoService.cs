using Application.Response;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Products
{
    public interface IProductoService
    {
        Task<ICollection<ProductoDto>> GetAllProducts();
        Task<ProductoDto> GetProductById(int productId);
        Task<ICollection<ProductoDto>> GetAllProductsByCarritoId(Guid carritoId);
    }
}
