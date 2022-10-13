using Domain.Dtos;

namespace Application.Interfaces.Carritos
{
    public interface ICarritoQuery
    {
        Task<CarritoDto> GetCartActiveByCustomerId(int customerId);
        Task<CarritoDto> GetCartById(Guid carritoId);
    }
}
