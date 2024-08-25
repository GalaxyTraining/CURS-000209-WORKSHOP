using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.GestionEducativa.Entidades;
using Workshop.GestionEducativa.Infraestructura.Dto.Request;
using Workshop.GestionEducativa.Infraestructura.Dto.Response;

namespace Workshop.GestionEducativa.Servicios.Interfaces
{
    public interface IApoderadoService
    {
        Task<ResponseBase<Apoderado>> Registrar(RegistroApoderadoDto request);
        Task<ResponseBase<List<ListarApoderadoDtoResponse>>> ListarTodos();
    }
}
