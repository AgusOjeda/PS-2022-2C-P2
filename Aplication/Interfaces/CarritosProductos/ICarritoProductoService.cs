using Application.Response;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CarritosProductos
{
    public interface ICarritoProductoService
    {
        void AddProductToCart(CarritoProducto item);
        void UpdateProduct(CarritoWithProductDataDto item);
        ICollection<CarritoWithProductDataDto> GetAllCarritoProducts(Guid carritoId);

    }
}
