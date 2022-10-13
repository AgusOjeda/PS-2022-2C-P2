using Domain.Dtos;
using Domain.Entities;

namespace Application.Mappers
{
    public static class CarritoProductoMapper
    {
        public static CarritoWithProductDataDto MapCarritoProducto(this CarritoProducto carritoProducto)
        {
            return new CarritoWithProductDataDto
            (
                CarritoId: carritoProducto.CarritoId,
                Cantidad: carritoProducto.Cantidad,
                Producto: carritoProducto.ProductoNavigation.MapProducto()
            );
        }
    }
}