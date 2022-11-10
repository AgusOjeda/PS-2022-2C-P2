using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Response
{
    public class ServerResponse<T>
    {
        public List<String> Errors { get; set; }
        public T Data { get; set; }
        public ServerResponse() => Errors = new List<string>();
        public bool IsValid { get => !Errors.Any(); }
    }
}
