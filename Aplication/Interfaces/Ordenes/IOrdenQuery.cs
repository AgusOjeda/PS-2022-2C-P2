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
    public interface IOrdenQuery
    {
        Task<BalancePerDayResponse> GetAllData();
        Task<BalancePerDayResponse> GetAllDataByDate(DateTime from, DateTime to);
        Task<BalancePerDayResponse> GetAllDataByDateSince(DateTime from);
        Task<BalancePerDayResponse> GetAllDataByDateUntil(DateTime to);
    }
}
