using Application.Interfaces.CarritosProductos;
using Application.Mappers;
using Domain.Dtos;
using Domain.Entities;
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

        public async Task<ICollection<CarritoWithProductDataDto>> GetAllProducts(Guid carritoId)
        {
            var list = await _context.CarritoProducto
                .Include(cp => cp.ProductoNavigation)
                .Where(x => x.CarritoId == carritoId)
                .Select(x => x.MapCarritoProducto())
                .ToListAsync();
            return list;
        }

        public async Task<CarritoProducto> GetById(Guid carritoId, int productoId)
        {
            var carritoProducto = await _context.CarritoProducto.FindAsync(carritoId, productoId);
            return carritoProducto;
        }
    }
}
