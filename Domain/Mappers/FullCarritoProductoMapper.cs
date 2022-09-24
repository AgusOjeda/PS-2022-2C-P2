using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class FullCarritoProductoMapper
    {
        public static FullCarritoProductoDto Map(this CarritoProducto source)
        {
            return new FullCarritoProductoDto { Cantidad = source.Cantidad, Producto = source.ProductoNavigation};
        }
    }
}
