using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class CarritoWithProductDataDto
    {
        public Guid CarritoId { get; set; }
        public int Cantidad { get; set; }
        public ProductoDto Producto { get; set; }
    }
}
