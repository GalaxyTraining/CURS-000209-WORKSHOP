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
    public class ApoderadoService : IApoderadoService
    {
        IApoderadoRepositorio _repositorio;
        public ApoderadoService(IApoderadoRepositorio repositorio) { 
            _repositorio = repositorio;
        }

        public Task<ResponseBase<Apoderado>> Registrar(RegistroApoderadoDto request)
        {
            return _repositorio.Registrar(request);
        }

        public Task<ResponseBase<List<ListarApoderadoDtoResponse>>> ListarTodos()
        {
            return _repositorio.ListarTodos();
        }
    }
}
