using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Request
{
    public record CreateClienteRequest(string Name, string LastName, string DNI, string Address, string PhoneNumber);

}
