using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class CarritoMapper
    {
        public static CarritoDto MapCarrito(this Carrito source)
        {
            return new CarritoDto
            {
                CarritoId = source.CarritoId,
                ClienteId = source.ClienteId,
                Estado = source.Estado,
                Nuevo = true
            };
        }
        public static Carrito MapCarrito(this CarritoDto source)
        {
            return new Carrito
            {
                CarritoId = source.CarritoId,
                ClienteId = source.ClienteId,
                Estado = source.Estado,
            };
        }
    }
}
