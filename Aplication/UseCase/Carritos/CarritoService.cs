using Application.Interfaces;
using Application.Interfaces.Carritos;
using Domain.Mappers;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ChangeState(CarritoDto cart)
        {
            var existingCart = _query.GetCartById(cart.CarritoId);
            if (existingCart == null)
                throw new Exception("El carrito no existe");
            else
            {
                existingCart.Estado = cart.Estado;
                var carUpdated = existingCart.MapCarrito();
                _command.Update(carUpdated);
            }
        }

        public CarritoDto CreateCart(int customerId)
        {
            var oldCart = HasCartActive(customerId);
            if (oldCart == null)
            {
                var newCart = new Carrito { CarritoId = new Guid(), ClienteId = customerId, Estado = true };
                _command.Insert(newCart);
                return newCart.MapCarrito();
            }
            else
            {
                oldCart.Nuevo = false;
                return oldCart;
            }
        }


        private CarritoDto HasCartActive(int customerId)
        {
            var cart = _query.GetCartActiveByCustomerId(customerId);
            if (cart != null)
                return cart;
            else
                return null;
        }
    }
}
