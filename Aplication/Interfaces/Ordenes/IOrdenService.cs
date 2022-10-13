using Domain.Dtos;
using Domain.Dtos.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Ordenes
{
    public interface IOrdenService
    {
        Task<bool> Crear(Guid carritoId, ICollection<CarritoWithProductDataDto> products);
        decimal TotalOrder(ICollection<CarritoWithProductDataDto> products);
        Task<BalancePerDayResponse> BalanceReport();
        Task<BalancePerDayResponse> BalanceReportFromTo(string from, string to);
        Task<BalancePerDayResponse> BalanceReportUntil(string to);
        Task<BalancePerDayResponse> BalanceReportSince(string from);
    }
}
  