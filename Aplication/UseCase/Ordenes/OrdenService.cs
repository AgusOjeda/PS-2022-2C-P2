using Application.Interfaces;
using Application.Interfaces.Ordenes;
using Domain.Dtos;
using Domain.Dtos.Response;
using Domain.Entities;

namespace Application.UseCase.Ordenes
{
    public class OrdenService : IOrdenService
    {
        private readonly ICommandHandler<Orden> _command;
        private readonly IOrdenQuery _query;
        
        public OrdenService(ICommandHandler<Orden> command, IOrdenQuery query)
        {
            _command = command;
            _query = query;
        }
        public async Task<NewOrdenResponse> Crear(Guid carritoId, ICollection<CarritoWithProductDataDto> products)
        {
            decimal total = TotalOrder(products);
            var newOrden = new Orden
            {
                OrdenId = Guid.NewGuid(),
                CarritoId = carritoId,
                Fecha = DateTime.Now,
                Total = total
            };
            await _command.Insert(newOrden);
            return new NewOrdenResponse(newOrden.OrdenId, newOrden.Fecha, newOrden.Total);
        }
        public async Task<BalancePerDayResponse> BalanceReport()
        {
            var report = await _query.GetAllData();
            return report;
        }
        public async Task<BalancePerDayResponse> BalanceReportFromTo(string from, string to)
        {
            var startDate = DateTime.Parse(from);
            var endDate = DateTime.Parse(to);
            var report = await _query.GetAllDataByDate(startDate, endDate);
            return report;
        }
        public async Task<BalancePerDayResponse> BalanceReportUntil(string to)
        {
            var endDate = DateTime.Parse(to);
            var report = await _query.GetAllDataByDateUntil(endDate);
            return report;
        }
        public async Task<BalancePerDayResponse> BalanceReportSince(string from)
        {
            var startDate = DateTime.Parse(from);
            var report = await _query.GetAllDataByDateSince(startDate);
            return report;
        }
        public decimal TotalOrder(ICollection<CarritoWithProductDataDto> products)
        {
            decimal total = 0;
            foreach (var item in products)
            {
                total += (item.Cantidad * item.Producto.Precio);
            }
            return total;
        }
    }
}
