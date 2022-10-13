using Application.Interfaces;
using Application.Interfaces.CarritosProductos;
using Domain.Dtos;
using Domain.Entities;

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

        public async Task AddProductToCart(CarritoProducto item)
        { 
            await _command.Insert(item);
        }

        public async Task UpdateProduct(CarritoProducto item)
        {
            var product = await _query.GetById(item.CarritoId, item.ProductoId);
            if (product != null)
            {
                item.Cantidad += product.Cantidad;
                await _command.Update(item);
            }
        }

        public async Task DeleteProduct(CarritoProducto item)
        {
            await _command.Delete(item);
        }
        public async Task<ICollection<CarritoWithProductDataDto>> GetAllCarritoProducts(Guid carritoId)
        {
            var carritoProducto = await _query.GetAllProducts(carritoId);
            return carritoProducto;
        }
    }
}
