using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class OrdenMapper
    {
        public static OrdenDto MapOrden(this Orden source)
        {
            return new OrdenDto
            {
                OrdenId = source.OrdenId,
                CarritoId = source.CarritoId,
                Fecha = source.Fecha,
                Total = source.Total,
            };
        }
        public static FullOrdenDto MapFullOrden(this Orden source)
        {
            return new FullOrdenDto
            {
                OrdenId = source.OrdenId,
                Fecha = source.Fecha,
                Total = source.Total,
                Carrito = new FullCarritoDto
                {
                    CarritoId = source.CarritoId,
                    Estado = source.CarritoNavigation.Estado,
                    Cliente = source.CarritoNavigation.ClienteNavigation.MapCliente(),
                    //Cliente = new ClienteDto { 
                    //    ClienteId = source.CarritoNavigation.ClienteId,
                    //    Nombre = source.CarritoNavigation.ClienteNavigation.Nombre,
                    //    Apellido = source.CarritoNavigation.ClienteNavigation.Apellido,
                    //    Direccion = source.CarritoNavigation.ClienteNavigation.Direccion,
                    //    DNI = source.CarritoNavigation.ClienteNavigation.DNI,
                    //    Telefono = source.CarritoNavigation.ClienteNavigation.Telefono
                    //},
                    CarritoProducto = source.CarritoNavigation.CarritoProductoNavigation.Select(x => x.Map()).ToList(),       
                }
            };
        }
    }
}
