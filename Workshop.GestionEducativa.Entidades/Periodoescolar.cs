using System;
using System.Collections.Generic;
using Workshop.GestionEducativa.Infraestructura.Dto.EntidadesBase;

namespace Workshop.GestionEducativa.Entidades;

public partial class Periodoescolar : EntidadBase
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Periodo { get; set; }

    public DateOnly? Fechainicio { get; set; }

    public DateOnly? Fechafin { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
