using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Products
{
    public interface IProductoQuery
    {
        ICollection<ProductoDto> GetAll();
        Task<ProductoDto> GetById(int id);
    }
}
