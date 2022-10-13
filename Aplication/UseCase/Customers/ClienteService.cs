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
            if(!await _query.FindByDni(model.DNI))
            {
                await _command.Insert(model.MapNewCliente());
                return new CreateClienteResponse(Message: "Cliente creado correctamente" );
            }
            return new CreateClienteResponse(Message: "El cliente ya existe");
        }
        public async Task<bool> FindCustomer(int id)
        {
            return await _query.FindById(id);
        }
    }
}
