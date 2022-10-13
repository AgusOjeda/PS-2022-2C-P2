using Domain.Dtos.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public static class OrdenMapper
    {
        public static SalesResponse Map(this Orden source)
        {
            return new SalesResponse
            (
                OrdenId: source.OrdenId,
                CarritoId: source.CarritoId,
                ClientName: source.CarritoNavigation.ClienteNavigation.Nombre,
                ClientDNI: source.CarritoNavigation.ClienteNavigation.DNI,
                Date: source.Fecha,
                Total: source.Total,
                Cart: new CartSalesResponse
                (
                    Products: source.CarritoNavigation.CarritoProductoNavigation.Select(x => new ProductSalesResponse
                    (
                        Nombre: x.ProductoNavigation.Nombre,
                        Marca: x.ProductoNavigation.Marca,
                        Codigo: x.ProductoNavigation.Codigo,
                        Precio: x.ProductoNavigation.Precio,
                        Cantidad: x.Cantidad,
                        ImagenUrl: x.ProductoNavigation.Image
                    )).ToList()
                )
            );
        }
    }
}
