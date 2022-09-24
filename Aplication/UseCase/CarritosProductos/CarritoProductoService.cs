using Application.Interfaces;
using Application.Interfaces.CarritosProductos;
using Domain.Mappers;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.CarritosProductos
{
    public class CarritoProductoService : ICarritoProductoService
    {
        private readonly ICommandHandler<CarritoProducto> _command;
        private readonly ICarritoProductoQuery _query;
        
        public CarritoProductoService(ICommandHandler<CarritoProducto> command, ICarritoProductoQuery query)
        {
            _command = command;
            _query = query;
        }

        public void AddProductToCart(CarritoProducto item)
        { 
             _command.Insert(item);
        }

        public void UpdateProduct(CarritoWithProductDataDto item)
        {
            _command.Update(item.MapCarritoProducto());
        }

        public ICollection<CarritoWithProductDataDto> GetAllCarritoProducts(Guid carritoId)
        {
            var carritoProducto = _query.GetAllProducts(carritoId);
            return carritoProducto;
        }
    }
}
