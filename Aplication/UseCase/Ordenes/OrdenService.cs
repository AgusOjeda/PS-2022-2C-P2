using Application.Interfaces;
using Application.Interfaces.Ordenes;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Ordenes
{
    public class OrdenService : IOrdenService
    {
        private readonly ICommandHandler<Orden> _command;
        private readonly IOrdenQuery _query;
        
        public OrdenService(ICommandHandler<Orden> command, IOrdenQuery query)
        {
            _command = command;
            _query = query;
        }
        public Orden Crear(Guid carritoId, decimal total)
        {
            var newOrden = new Orden
            {
                CarritoId = carritoId,
                Fecha = DateTime.Now,
                Total = total
            };

            _command.Insert(newOrden);

            return newOrden;
        }

        public ICollection<FullOrdenDto> GetAllDataByProductId(int productId)
        {
            return _query.GetAllDataByProductName(productId);
        }

        public ICollection<FullOrdenDto> GetAllOrden()
        {
            return _query.GetAllData();
        }
    }
}
