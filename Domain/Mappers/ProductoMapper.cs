using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class ProductoMapper
    {
        public static ProductoDto MapProducto(this Producto source)
        {
            return new ProductoDto {
                ProductoId = source.ProductoId,
                Nombre = source.Nombre,
                Descripcion = source.Descripcion,
                Precio = source.Precio,
                Marca = source.Marca,
                };
        }
    }
}
