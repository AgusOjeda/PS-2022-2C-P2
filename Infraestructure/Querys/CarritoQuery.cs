using Application.Interfaces.Carritos;
using Domain.Dtos;
using Domain.Entities;
using Infraestructure.Persistence;
using Domain.Mappers;
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
        
        public CarritoDto GetCartActiveByCustomerId(int customerId)
        {
            var entity = _context.Carrito.AsNoTracking().Where(x => x.ClienteId == customerId && x.Estado == true).FirstOrDefault();
            if (entity != null) return entity.MapCarrito();
            else return null;
            
        }

        public CarritoDto GetCartById(Guid carritoId)
        {
            var entity = _context.Carrito.AsNoTracking().Where(x => x.CarritoId == carritoId).FirstOrDefault();
            if (entity != null) return entity.MapCarrito();
            else return null;
        }
    }
}
