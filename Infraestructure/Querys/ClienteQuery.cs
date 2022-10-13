using Application.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Application.Mappers;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly AppDbContext _context;

        public ClienteQuery(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> FindByDni(string dni)
        {
            var customer = await _context.Cliente.FirstOrDefaultAsync(x => x.DNI == dni);
            if (customer == null)
            {
                return false;
            }
            return true;
        }
        
        public async Task<bool> FindById(int id)
        {
            var customer = await _context.Cliente.FindAsync(id);
            if (customer == null)
            {
                return false;
            }
            return true;
        }
    }
}
