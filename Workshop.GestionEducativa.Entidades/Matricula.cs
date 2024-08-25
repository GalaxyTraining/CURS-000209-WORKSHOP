using System;
using System.Collections.Generic;
using Workshop.GestionEducativa.Infraestructura.Dto.EntidadesBase;

namespace Workshop.GestionEducativa.Entidades;

public partial class Matricula : EntidadBase
{
    public int Id { get; set; }

    public int? Idalumno { get; set; }

    public int? Idgrado { get; set; }

    public int? Idperiodoescolar { get; set; }

    public virtual Alumno? IdalumnoNavigation { get; set; }

    public virtual Grado? IdgradoNavigation { get; set; }

    public virtual Periodoescolar? IdperiodoescolarNavigation { get; set; }
}
