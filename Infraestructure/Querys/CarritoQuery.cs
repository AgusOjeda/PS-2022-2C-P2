using Application.Interfaces.Carritos;
using Domain.Dtos;
using Infraestructure.Persistence;
using Application.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class CarritoQuery : ICarritoQuery
    {
        private readonly AppDbContext _context;

        public CarritoQuery(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<CarritoDto> GetCartActiveByCustomerId(int customerId)
        {
            var entity = await _context.Carrito
                .AsNoTracking()
                .Where(x => x.ClienteId == customerId && x.Estado)
                .FirstOrDefaultAsync();
            if (entity != null) return entity.MapCarrito();
            else return null;
            
        }

        public async Task<CarritoDto> GetCartById(Guid carritoId)
        {
            var entity = await _context.Carrito
                .AsNoTracking()
                .Where(x => x.CarritoId == carritoId)
                .FirstOrDefaultAsync();
            if (entity != null) return entity.MapCarrito();
            else return null;
        }
    }
}
