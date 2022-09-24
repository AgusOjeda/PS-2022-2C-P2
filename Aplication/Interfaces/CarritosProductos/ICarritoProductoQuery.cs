using Domain.Dtos;
using Domain.Entities;

namespace Application.Interfaces.CarritosProductos
{
    public interface ICarritoProductoQuery
    {
        ICollection<CarritoWithProductDataDto> GetAllProducts(Guid carritoId);
    }
}
