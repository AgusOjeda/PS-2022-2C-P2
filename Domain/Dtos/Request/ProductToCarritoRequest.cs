using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Request
{
    public record ProductToCarritoRequest(int ClientId, int ProductId, int Amount);

}
