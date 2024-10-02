using Microsoft.AspNetCore.Mvc;
using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.DTO;
using ProyectoProgramacion2.Servicio;
using static ProyectoProgramacion2.Response.TareaResponses;
using static ProyectoProgramacion2.Response.ProyectoResponses;
namespace ProyectoProgramacion2.Controllers
{
    [ApiController]
    [Route("ProyectoProgramacion2/[[Controllers]]")]
    public class ProyectoController : Controller
    {
        private readonly ProyectoService _proyectoService;
        public ProyectoController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ProyectoDBContext>();
            _proyectoService = new ProyectoService(context);
        }
        [HttpGet("obtener-proyectos")]
        public async Task<ActionResult<ProyectosResponse>> GetProyectos()
        {
            var proyectos = await _proyectoService.ListaProyecto();

            var response = new ProyectosResponse
            {
                Data = proyectos,
                Code = 200,
                Message = "Proyectos obtenidos correctamente"
            };

            return Ok(response);
        }

        [HttpGet("obtener-proyecto")]
        public async Task<ActionResult<ProyectoResponse>> GetProyecto(int id)
        {
            var proyecto = await _proyectoService.ObtenerProyecto(id);

            var response = new ProyectoResponse
            {
                Data = proyecto,
                Code = 200,
                Message = "Proyecto obtenido correctamente"
            };

            return Ok(response);

        }

        [HttpPost("ingresar-proyecto")]
        public async Task<ActionResult<NuevoProyectoResponse>> PostProyecto([FromBody] ProyectoDTO proyecto)
        {
            var ingreso = await _proyectoService.IngresarProyecto(proyecto);

            var response = new NuevoProyectoResponse
            {
                Data = ingreso,
                Code = 200,
                Message = "Proyecto ingresado correctamente"
            };

            return Ok(response);
        }

    }
}
