using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CarritoProducto : IEntity
    {
        public Guid CarritoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        public virtual Carrito CarritoNavigation { get; set; } = null!;
        public virtual Producto ProductoNavigation { get; set; }
    }
}
