using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    public class ApoderadoRepositorio : IApoderadoRepositorio
    {
        private GestionDbContext _context;

        public ApoderadoRepositorio(GestionDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<Apoderado>> Registrar(RegistroApoderadoDto request)
        {
            ResponseBase<Apoderado> resultado = new ResponseBase<Apoderado>();
            try
            {
                ValidarCampos(request);
                var nuevo = new Apoderado()
                {
                    Nombre = request.nombre,
                    Apellidos = request.apellidos,
                    Direccion = request.direccion,
                    Celular = request.celular,
                    Numerodocumento = request.documento,
                    Correoelectronico = request.email
                };

                var apoderado = await _context.Apoderados.AddAsync(nuevo);
                await _context.SaveChangesAsync();
                resultado.message = "Registro de apoderado exitoso";
                resultado.data = apoderado.Entity;
                Logger.LogInfo(resultado.message);
            }
            catch (Exception ex)
            {
                resultado.success = false;
                resultado.message = ex.Message;
                Logger.LogError($"Hubo un error en el registro de apoderados: {ex.Message}");
            }
            return resultado;
        }

        public async Task<ResponseBase<List<ListarApoderadoDtoResponse>>> ListarTodos()
        {
            ResponseBase<List<ListarApoderadoDtoResponse>> resultado = new ResponseBase<List<ListarApoderadoDtoResponse>>();

            try
            {
                var apoderados = await (from item in _context.Apoderados
                                  select new ListarApoderadoDtoResponse
                                  {
                                      Apoderado = $"{item.Nombre} {item.Apellidos}",
                                      DocumentoIdentidad = item.Numerodocumento!,
                                      Celular = item.Celular!,
                                      Correo = item.Correoelectronico!,
                                      Direccion = item.Direccion!
                                  })
                                  .AsNoTracking()
                                  .ToListAsync();

                resultado.message = "Listado de apoderados exitoso";
                resultado.data = apoderados;
                Logger.LogInfo(resultado.message);
            }
            catch (Exception ex)
            {
                resultado.success = false;
                resultado.message = ex.Message;
                Logger.LogError($"Hubo un error en el listado de apoderados: {ex.Message}");
            }
            return resultado;
        }

        private void ValidarCampos(RegistroApoderadoDto request)
        {
            if (request.nombre == string.Empty)
                throw new CustomException("El nombre del apoderado es requerido.");

            if (request.apellidos == string.Empty)
                throw new CustomException("los apellidos del apoderado es requerido.");

            if (request.email == string.Empty)
                throw new CustomException("El email del apoderado es requerido.");

            if (request.documento == string.Empty)
                throw new CustomException("El documento del apoderado es requerido.");

            if (request.celular == string.Empty)
                throw new CustomException("El celular del apoderado es requerido.");
        }

    }
}
