using System;
using System.Collections.Generic;
using Workshop.GestionEducativa.Infraestructura.Dto.EntidadesBase;

namespace Workshop.GestionEducativa.Entidades;

public partial class Grado : EntidadBase
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
