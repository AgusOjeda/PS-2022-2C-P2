using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Response
{
    public record NewOrdenResponse(Guid OrdenId, DateTime Fecha, decimal Total);
}
