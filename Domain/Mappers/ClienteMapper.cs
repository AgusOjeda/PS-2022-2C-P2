using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class ClienteMapper
    {
        public static ClienteDto MapCliente(this Cliente source)
        {
            return new ClienteDto
            {
                ClienteId = source.ClienteId,
                Nombre = source.Nombre,
                Apellido = source.Apellido,
                Direccion = source.Direccion,
                Telefono = source.Telefono,
                DNI = source.DNI
            };
        }
    }
}
