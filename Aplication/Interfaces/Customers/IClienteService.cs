using Domain.Dtos;
using Domain.Dtos.Request;
using Domain.Dtos.Response;



namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<CreateClienteResponse> CreateCustomer(CreateClienteRequest model);
        Task<bool> FindCustomer(int id);
    }
}
