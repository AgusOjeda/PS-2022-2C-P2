using Domain.Dtos;
using Domain.Entities;

namespace Application.Interfaces.CarritosProductos
{
    public interface ICarritoProductoService
    {
        Task AddProductToCart(CarritoProducto item);
        Task UpdateProduct(CarritoProducto item);
        Task DeleteProduct(CarritoProducto item);
        Task<ICollection<CarritoWithProductDataDto>> GetAllCarritoProducts(Guid carritoId);
    }
}
