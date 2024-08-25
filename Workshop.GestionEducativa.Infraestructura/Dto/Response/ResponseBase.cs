using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.GestionEducativa.Infraestructura.Dto.Response
{
    public class ResponseBase<T>
    {
        public string? message { get; set; }
        public bool success { get; set; } = true;
        public T? data { get; set; }
    }
}
