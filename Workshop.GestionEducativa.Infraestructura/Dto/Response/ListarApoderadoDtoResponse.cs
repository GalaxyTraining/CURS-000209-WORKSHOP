using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.GestionEducativa.Infraestructura.Dto.Response
{
    public class ListarApoderadoDtoResponse
    {
        public string Apoderado { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string DocumentoIdentidad { get; set; }
    }
}
