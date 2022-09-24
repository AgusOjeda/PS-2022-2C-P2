using Application.Response;
using Domain.Dtos;
using Domain.Entities;
using Domain.Models;


namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDto> CreateCustomer();
        ClienteDto GetCustomerByDni(string dni);
    }
}
