using Domain.Dtos.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHandlerProductToCart
    {
        Task<bool> HandleAdd(ProductToCarritoRequest request);
        Task<bool> HandleUpdate(ProductToCarritoRequest request);
        Task<bool> HandleDelete(int clientId, int productId);
    }
}
