using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Ordenes
{
    public interface IOrdenQuery
    {
        ICollection<FullOrdenDto> GetAllData();
        ICollection<FullOrdenDto> GetAllDataByProductName(int productId);
    }
}
