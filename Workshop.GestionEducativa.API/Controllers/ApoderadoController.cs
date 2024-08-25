using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workshop.GestionEducativa.Infraestructura.Dto.Request;
using Workshop.GestionEducativa.Servicios.Interfaces;

namespace Workshop.GestionEducativa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApoderadoController : ControllerBase
    {
        IApoderadoService _apoderadoService;
        public ApoderadoController(IApoderadoService apoderadoService)
        {
            _apoderadoService = apoderadoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegistroApoderadoDto request)
        {
            var result = await _apoderadoService.Registrar(request);
            if (result.success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _apoderadoService.ListarTodos();
            if (result.success)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}
