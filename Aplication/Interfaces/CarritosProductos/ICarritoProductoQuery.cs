using Domain.Dtos;
using Domain.Entities;

namespace Application.Interfaces.CarritosProductos
{
    public interface ICarritoProductoQuery
    {
        Task<ICollection<CarritoWithProductDataDto>> GetAllProducts(Guid carritoId);
        Task<CarritoProducto> GetById(Guid carritoId, int productoId);
    }
}
