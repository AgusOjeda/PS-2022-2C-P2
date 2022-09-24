using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Ordenes
{
    public interface IOrdenService
    {
        Orden Crear(Guid carritoId, decimal total);
        ICollection<FullOrdenDto> GetAllOrden();

        ICollection<FullOrdenDto> GetAllDataByProductId(int productId);
    }
}
