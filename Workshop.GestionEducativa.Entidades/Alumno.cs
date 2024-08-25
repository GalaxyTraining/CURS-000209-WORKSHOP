using System;
using System.Collections.Generic;
using Workshop.GestionEducativa.Infraestructura.Dto.EntidadesBase;

namespace Workshop.GestionEducativa.Entidades;

public partial class Alumno : EntidadBase
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public DateOnly? Fechanacimiento { get; set; }

    public string? Numerodocumento { get; set; }

    public int? Idapoderado { get; set; }

    public virtual Apoderado? IdapoderadoNavigation { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
