using Application.Interfaces;
using Application.Mappers;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
#nullable disable
namespace Application.UseCase.Customers
{
    public class ClienteService : IClienteService
    {
        private readonly ICommandHandler<Cliente> _command;
        private readonly IClienteQuery _query;
        public ClienteService(ICommandHandler<Cliente> command, IClienteQuery query)
        {
            _command = command;
            _query = query;
        }
        public async Task<CreateClienteResponse> CreateCustomer(CreateClienteRequest model)
        {
            var cliente = await _query.FindByDni(model.DNI);
            if (cliente == null)
            {
                await _command.Insert(model.MapNewCliente());
                cliente = await _query.FindByDni(model.DNI);
                return new CreateClienteResponse(cliente, NewUser: true);
            }
            return new CreateClienteResponse(cliente, NewUser: false);
        }
        public async Task<bool> FindCustomer(int id)
        {
            return await _query.FindById(id);
        }
    }
}
