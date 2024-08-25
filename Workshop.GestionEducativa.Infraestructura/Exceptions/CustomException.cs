using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.GestionEducativa.Infraestructura.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string mensaje) : base(mensaje) { }
    }
}
