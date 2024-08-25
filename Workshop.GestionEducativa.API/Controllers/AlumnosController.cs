using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshop.GestionEducativa.Infraestructura.Dto.Request;
using Workshop.GestionEducativa.Servicios.Interfaces;

namespace Workshop.GestionEducativa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        IAlumnoService _AlumnoService;
        public AlumnosController(IAlumnoService AlumnoService)
        {
            _AlumnoService = AlumnoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AlumnoDtoRequest request)
        {
            var result = await _AlumnoService.Registrar(request);
            if (result.success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut("{idAlumno:int}")]
        public async Task<IActionResult> Put(int idAlumno, AlumnoDtoRequest request)
        {
            var result = await _AlumnoService.Actualizar(idAlumno, request);
            if (result.success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _AlumnoService.ListarTodos();
            if (result.success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet("{idAlumno:int}")]
        public async Task<IActionResult> Get(int idAlumno)
        {
            var result = await _AlumnoService.ListarTodos();
            if (result.success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
