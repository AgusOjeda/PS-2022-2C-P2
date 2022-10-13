using Domain.Dtos.Response;

namespace Application.Interfaces.Handlers
{
    public interface IOrdenHandler
    {
        Task<bool> GenerateOrder(int clientId);
        Task<BalancePerDayResponse> GenerateBalanceReport(string? from, string? to);
    }
}
