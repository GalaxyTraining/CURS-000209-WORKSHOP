using System;
using System.Collections.Generic;
using Workshop.GestionEducativa.Infraestructura.Dto.EntidadesBase;

namespace Workshop.GestionEducativa.Entidades;

public partial class Apoderado : EntidadBase
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Numerodocumento { get; set; }

    public string? Correoelectronico { get; set; }

    public string? Celular { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
