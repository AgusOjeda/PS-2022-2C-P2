using Domain.Dtos;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public static class ClienteMapper
    {
        public static Cliente MapNewCliente(this CreateClienteRequest request)
        {
            return new Cliente
            {
                Nombre = request.Name,
                Apellido = request.LastName,
                DNI = request.DNI,
                Direccion = request.Address,
                Telefono = request.PhoneNumber
            };
        }
        public static ClienteDto Map(this Cliente request)
        {
            return new ClienteDto
            {
                ClienteId = request.ClienteId,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                DNI = request.DNI,
                Direccion = request.Direccion,
                Telefono = request.Telefono
            };
        }
    }
}
