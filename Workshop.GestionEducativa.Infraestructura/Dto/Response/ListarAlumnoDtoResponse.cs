using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.GestionEducativa.Infraestructura.Dto.Response
{
    public class ListarAlumnoDtoResponse
    {
        public string Alumno { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string Documento { get; set; }
        public string Apoderado { get; set; }
    }
}
