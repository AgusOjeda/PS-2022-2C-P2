using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Carritos
{
    public interface ICarritoService
    {
        Task<bool> ChangeState(Guid cartId);
        Task<Guid> ActiveCart(int customerId);
        Task<CarritoDto> HasCartActive(int customerId);
    }
}
