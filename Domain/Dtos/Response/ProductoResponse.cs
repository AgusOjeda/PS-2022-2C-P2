using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Response
{
    public record ProductoResponse(
        string Nombre,
        string Descripcion,
        string Marca,
        string Codigo,
        decimal Precio,
        string ImagenUrl);
}
