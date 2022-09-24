using Application.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Domain.Mappers;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly AppDbContext _context;

        public ClienteQuery(AppDbContext context)
        {
            _context = context;
        }

        public ClienteDto GetCustomerByDni(string dni)
        {
            var customer = _context.Cliente.FirstOrDefault(x => x.DNI == dni);
            if (customer == null) return null;
            else return ClienteMapper.MapCliente(customer);
        }
    }
}
