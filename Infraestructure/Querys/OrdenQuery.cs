using Application.Interfaces.Ordenes;
using Domain.Dtos;
using Application.Mappers;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Dtos.Response;

namespace Infraestructure.Querys
{
    public class OrdenQuery : IOrdenQuery
    {
        private readonly AppDbContext _context;

        public OrdenQuery(AppDbContext context)
        {
            _context = context;
        }
        public async Task<BalancePerDayResponse> GetAllDataByDate(DateTime from, DateTime to)
        {

            var data = await _context.Orden
                .Where(x => x.Fecha.DayOfYear >= from.DayOfYear && x.Fecha.DayOfYear <= to.DayOfYear)
                .Include(orden => orden.CarritoNavigation)
                .Include(orden => orden.CarritoNavigation.CarritoProductoNavigation)
                .ThenInclude(x => x.ProductoNavigation)
                .Include(orden => orden.CarritoNavigation.ClienteNavigation)
                .Select(x => x.Map())
                .AsNoTracking()
                .ToListAsync();

            return new BalancePerDayResponse(TotalRevenue: data.Sum(x => x.Total), Sales: data);
        }
        public async Task<BalancePerDayResponse> GetAllDataByDateUntil(DateTime to)
        {

            var data = await _context.Orden
                .Where(x => x.Fecha.DayOfYear <= to.DayOfYear)
                .Include(orden => orden.CarritoNavigation)
                .Include(orden => orden.CarritoNavigation.CarritoProductoNavigation)
                .ThenInclude(x => x.ProductoNavigation)
                .Include(orden => orden.CarritoNavigation.ClienteNavigation)
                .Select(x => x.Map())
                .AsNoTracking()
                .ToListAsync();

            return new BalancePerDayResponse(TotalRevenue: data.Sum(x => x.Total), Sales: data);
        }
        public async Task<BalancePerDayResponse> GetAllDataByDateSince(DateTime from)
        {

            var data = await _context.Orden
                .Where(x => x.Fecha.DayOfYear >= from.DayOfYear)
                .Include(orden => orden.CarritoNavigation)
                .Include(orden => orden.CarritoNavigation.CarritoProductoNavigation)
                .ThenInclude(x => x.ProductoNavigation)
                .Include(orden => orden.CarritoNavigation.ClienteNavigation)
                .Select(x => x.Map())
                .AsNoTracking()
                .ToListAsync();

            return new BalancePerDayResponse(TotalRevenue: data.Sum(x => x.Total), Sales: data);
        }

        public async Task<BalancePerDayResponse> GetAllData()
        {
            var data = await _context.Orden
                .Include(orden => orden.CarritoNavigation)
                .Include(orden => orden.CarritoNavigation.CarritoProductoNavigation)
                .ThenInclude(x => x.ProductoNavigation)
                .Include(orden => orden.CarritoNavigation.ClienteNavigation)
                .Select(x => x.Map())
                .AsNoTracking()
                .ToListAsync();
            return new BalancePerDayResponse(TotalRevenue: data.Sum(x => x.Total), Sales: data);
        }
    }
}
