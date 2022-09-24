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
        CarritoDto CreateCart(int customerId);
        void ChangeState(CarritoDto cart);
    }
}
