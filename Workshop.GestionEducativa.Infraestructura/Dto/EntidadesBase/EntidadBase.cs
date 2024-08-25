using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.GestionEducativa.Infraestructura.Dto.EntidadesBase
{
    public class EntidadBase
    {
        public bool? Estado { get; set; } = true;

        public DateOnly? Fecharegistro { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public string? Usuarioregistro { get; set; } = "Admin";
    }
}
