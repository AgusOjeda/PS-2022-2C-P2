using Domain.Dtos;

namespace Application.Interfaces.Carritos
{
    public interface ICarritoQuery
    {
        CarritoDto GetCartActiveByCustomerId(int customerId);
        CarritoDto GetCartById(Guid carritoId);
    }
}
