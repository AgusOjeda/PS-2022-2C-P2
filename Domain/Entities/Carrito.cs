using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Carrito : IEntity
    {
        public Guid CarritoId { get; set; }
        public int ClienteId { get; set; }
        public Boolean Estado { get; set; }

        public Cliente ClienteNavigation { get; set; }
        public Orden OrdenNavigation { get; set; }

        public ICollection<CarritoProducto> CarritoProductoNavigation { get; set; }
    }
}
