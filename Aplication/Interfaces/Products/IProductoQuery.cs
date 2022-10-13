using Domain.Dtos;
using Domain.Dtos.Response;
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
        Task<ProductoResponse> GetById(int id);
        Task<IList<ProductoResponse>> GetProductsByNameSorted(string name, bool order);
        Task<IList<ProductoResponse>> GetProductsSorted(bool order);
        Task<bool> FindById(int id);
    }
}
