using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class CarritoProductoMapper
    {
        public static CarritoWithProductDataDto MapCarritoProducto(this CarritoProducto carritoProducto)
        {
            return new CarritoWithProductDataDto
            {
                CarritoId = carritoProducto.CarritoId,
                Cantidad = carritoProducto.Cantidad,
                Producto = carritoProducto.ProductoNavigation.MapProducto()
            };
        }
        public static CarritoProducto MapCarritoProducto(this CarritoProductoDto carritoProducto)
        {
            return new CarritoProducto
            {
                CarritoId = carritoProducto.CarritoId,
                Cantidad = carritoProducto.Cantidad,
                ProductoId = carritoProducto.ProductoId
            };
        }
        public static CarritoProducto MapCarritoProducto(this CarritoWithProductDataDto carritoProducto)
        {
            return new CarritoProducto
            {
                CarritoId = carritoProducto.CarritoId,
                Cantidad = carritoProducto.Cantidad,
                ProductoId = carritoProducto.Producto.ProductoId
            };
        }
    }
}