using Application.Interfaces;
using Application.Interfaces.Carritos;
using Application.Mappers;
using Domain.Dtos;
using Domain.Entities;

namespace Application.UseCase.Carritos
{
    public class CarritoService : ICarritoService
    {
        private readonly ICommandHandler<Carrito> _command;
        private readonly ICarritoQuery _query;
        public CarritoService(ICommandHandler<Carrito> command, ICarritoQuery query)
        {
            _command = command;
            _query = query;
        }
        public async Task<bool> ChangeState(Guid cartId)
        {
            var existingCart = await _query.GetCartById(cartId);
            if (existingCart == null)
            {
                return false;
            }
            else
            {
                var carUpdated = existingCart.MapCarrito();
                carUpdated.Estado = false;
                await _command.Update(carUpdated);
                return true;
            }
        }
        public async Task<Guid> ActiveCart(int customerId)
        {
            var cart = await HasCartActive(customerId);
            if (cart == null)
            {
                cart = await CreateCart(customerId);
            }
            return cart.CarritoId;
        }
        private async Task<CarritoDto> CreateCart(int customerId)
        {
            var newCart = new Carrito { CarritoId = Guid.NewGuid(), ClienteId = customerId, Estado = true };
            await _command.Insert(newCart);
            return newCart.MapCarrito();
        }
        public async Task<CarritoDto> HasCartActive(int customerId)
        {
            var cart = await _query.GetCartActiveByCustomerId(customerId);
            if (cart != null)
                return cart;
            else
                return null;
        }
    }
}
