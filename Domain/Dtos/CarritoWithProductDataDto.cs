using Domain.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public record CarritoWithProductDataDto(Guid CarritoId, int Cantidad, ProductoResponse Producto);
}
