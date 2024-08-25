using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.GestionEducativa.Entidades;
using Workshop.GestionEducativa.Infraestructura.Dto.Request;
using Workshop.GestionEducativa.Infraestructura.Dto.Response;

namespace Workshop.GestionEducativa.Repositorios.Interfaces
{
    public interface IAlumnoRepositorio
    {
        Task<ResponseBase<Alumno>> Registrar(AlumnoDtoRequest request);
        Task<ResponseBase<List<ListarAlumnoDtoResponse>>> ListarTodos();
        Task<ResponseBase<Alumno>> Actualizar(int IdAlumno, AlumnoDtoRequest request);
    }
}
