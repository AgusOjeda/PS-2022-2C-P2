using Application.Interfaces.Ordenes;
using Domain.Dtos;
using Domain.Mappers;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class OrdenQuery : IOrdenQuery
    {
        private readonly AppDbContext _context;

        public OrdenQuery(AppDbContext context)
        {
            _context = context;
        }
        
        public ICollection<FullOrdenDto> GetAllData()
        {
            var data = _context.Orden
                .Include(orden => orden.CarritoNavigation)
                .Include(orden => orden.CarritoNavigation.ClienteNavigation)
                .Include(orden => orden.CarritoNavigation.CarritoProductoNavigation)
                .ThenInclude(x => x.ProductoNavigation)
                .Select(x => x.MapFullOrden())
                .AsNoTracking()
                .ToList();
            if(data.Any())
                return data;
            else
                return null;
        }
        public ICollection<FullOrdenDto> GetAllDataByProductName(int productId)
        {
            var data = _context.Orden
                .Include(orden => orden.CarritoNavigation)
                .Include(orden => orden.CarritoNavigation.CarritoProductoNavigation.Where(x => x.ProductoId == productId))
                .ThenInclude(x => x.ProductoNavigation)
                .Include(orden => orden.CarritoNavigation.ClienteNavigation)
                .Select(x => x.MapFullOrden())
                .AsNoTracking()
                .ToList();

            return data;
        }
    }
}
