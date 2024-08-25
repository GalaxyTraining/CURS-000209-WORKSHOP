using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.GestionEducativa.Infraestructura.Dto.Request
{
    public class RegistroApoderadoDto
    {
        //[Required(ErrorMessage = "El nombre del apoderado es requerido")]
        public string nombre { get; set; }

        public string apellidos { get; set; }
        public string documento { get; set; }
        public string email { get; set; }

        //[Range(9, 9, ErrorMessage = "El numero de celular debe tener como maximo 9 digitos.")]
        public string celular { get; set; }
        public string direccion { get; set; }
    }
}
