using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.GestionEducativa.Entidades;
using Workshop.GestionEducativa.Infraestructura.Dto.Request;
using Workshop.GestionEducativa.Infraestructura.Dto.Response;
using Workshop.GestionEducativa.Repositorios.Interfaces;
using Workshop.GestionEducativa.Servicios.Interfaces;

namespace Workshop.GestionEducativa.Servicios.Implementaciones
{
    public class AlumnoService : IAlumnoService
    {
        IAlumnoRepositorio _repositorio;
        public AlumnoService(IAlumnoRepositorio repositorio) { 
            _repositorio = repositorio;
        }

        public Task<ResponseBase<Alumno>> Registrar(AlumnoDtoRequest request)
        {
            return _repositorio.Registrar(request);
        }

        public Task<ResponseBase<List<ListarAlumnoDtoResponse>>> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }

        public Task<ResponseBase<Alumno>> Actualizar(int IdAlumno, AlumnoDtoRequest request)
        {
            return _repositorio.Actualizar(IdAlumno, request);
        }
    }
}
