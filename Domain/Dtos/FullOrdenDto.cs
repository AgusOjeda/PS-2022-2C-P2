using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class FullOrdenDto
    {

        public Guid OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public FullCarritoDto Carrito { get; set; }
    }
}
