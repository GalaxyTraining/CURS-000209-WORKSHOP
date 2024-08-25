using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.GestionEducativa.Infraestructura.Dto.Request
{
    public class AlumnoDtoRequest
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Documento { get; set; }
        public int IdApoderado { get; set; }
    }
}
