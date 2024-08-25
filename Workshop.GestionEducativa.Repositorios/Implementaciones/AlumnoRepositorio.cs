using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.GestionEducativa.AccesoDatos.Contextos;
using Workshop.GestionEducativa.Entidades;
using Workshop.GestionEducativa.Infraestructura.Dto.Request;
using Workshop.GestionEducativa.Infraestructura.Dto.Response;
using Workshop.GestionEducativa.Infraestructura.Exceptions;
using Workshop.GestionEducativa.Infraestructura.LoggerService;
using Workshop.GestionEducativa.Repositorios.Interfaces;

namespace Workshop.GestionEducativa.Repositorios.Implementaciones
{
    public class AlumnoRepositorio : IAlumnoRepositorio
    {
        private GestionDbContext _context;

        public AlumnoRepositorio(GestionDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<Alumno>> Registrar(AlumnoDtoRequest request)
        {
            ResponseBase<Alumno> resultado = new ResponseBase<Alumno>();
            try
            {
                var nuevo = new Alumno()
                {
                    Nombre = request.Nombre,
                    Apellidos = request.Apellidos,
                    Fechanacimiento = DateOnly.FromDateTime(request.FechaNacimiento),
                    Idapoderado = request.IdApoderado,
                    Numerodocumento = request.Documento
                };

                var Alumno = await _context.Alumnos.AddAsync(nuevo);
                await _context.SaveChangesAsync();
                resultado.message = "Registro de Alumno exitoso";
                resultado.data = Alumno.Entity;
                Logger.LogInfo(resultado.message);
            }
            catch (Exception ex)
            {
                resultado.success = false;
                resultado.message = ex.Message;
                Logger.LogError($"Hubo un error en el registro de alumno: {ex.Message}");
            }
            return resultado;
        }

        public async Task<ResponseBase<Alumno>> Actualizar(int IdAlumno, AlumnoDtoRequest request)
        {
            ResponseBase<Alumno> resultado = new ResponseBase<Alumno>();
            try
            {
               await _context.Alumnos
                    .Where(a => a.Id == IdAlumno)
                    .ExecuteUpdateAsync(alumno => alumno
                        .SetProperty(p => p.Nombre, request.Nombre)
                        .SetProperty(p => p.Apellidos, request.Apellidos)
                        .SetProperty(p => p.Numerodocumento, request.Documento)
                        .SetProperty(p => p.Idapoderado, request.IdApoderado)
                        .SetProperty(p=> p.Fechanacimiento, DateOnly.FromDateTime(request.FechaNacimiento)));

                resultado.message = "Registro de Alumno exitoso";
                Logger.LogInfo(resultado.message);
            }
            catch (Exception ex)
            {
                resultado.success = false;
                resultado.message = ex.Message;
                Logger.LogError($"Hubo un error en la actualizacion de alumno: {ex.Message}");
            }
            return resultado;
        }

        public async Task<ResponseBase<List<ListarAlumnoDtoResponse>>> ListarTodos()
        {
            ResponseBase<List<ListarAlumnoDtoResponse>> resultado = new ResponseBase<List<ListarAlumnoDtoResponse>>();

            try
            {
                var Alumnos = await (from item in _context.Alumnos
                                  select new ListarAlumnoDtoResponse
                                  {
                                      Alumno = $"{item.Nombre} {item.Apellidos}",
                                      Documento = item.Numerodocumento!,
                                      FechaNacimiento = item.Fechanacimiento!,
                                      Apoderado = $"{item.IdapoderadoNavigation!.Nombre} {item.IdapoderadoNavigation.Apellidos}"
                                  })
                                  .AsNoTracking()
                                  .ToListAsync();

                resultado.message = "Listado de Alumnos exitoso";
                resultado.data = Alumnos;
                Logger.LogInfo(resultado.message);
            }
            catch (Exception ex)
            {
                resultado.success = false;
                resultado.message = ex.Message;
                Logger.LogError($"Hubo un error en el listado de alumno: {ex.Message}");
            }
            return resultado;
        }

    }
}
