using Application.Interfaces.CarritosProductos;
using Domain.Mappers;
using Domain.Dtos;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Querys
{
    public class CarritoProductoQuery : ICarritoProductoQuery
    {
        private readonly AppDbContext _context;

        public CarritoProductoQuery(AppDbContext context)
        {
            _context = context;
        }
        // Returns a collection with the entries in the CarritoProducto table
        // and their contents related to the Product table corresponding to the Id passed as parameter.
        public ICollection<CarritoWithProductDataDto> GetAllProducts(Guid carritoId)
        {
            var list = _context.CarritoProducto.Include(cp => cp.ProductoNavigation).Where(x => x.CarritoId == carritoId).Select(x => x.MapCarritoProducto()).ToList();
            if(list == null)
            {
                return null;
            }
            else
            {
                return list;
            }
        }

        
    }
}
