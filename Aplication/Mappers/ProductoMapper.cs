using Domain.Dtos.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public static class ProductoMapper
    {
        public static ProductoResponse MapProducto(this Producto source)
        {
            return new ProductoResponse
            (
                Nombre: source.Nombre,
                Descripcion: source.Descripcion,
                Marca: source.Marca,
                Codigo: source.Codigo,
                Precio: source.Precio,
                ImagenUrl: source.Image
            );
        }
    }
}
