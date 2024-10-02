using Microsoft.AspNetCore.Mvc;
using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.DTO;
using ProyectoProgramacion2.Servicio;
using static ProyectoProgramacion2.Response.HerramientaResponses;
namespace ProyectoProgramacion2.Controllers
{
    [ApiController]
    [Route("ProyectoProgramacion2/[[Controllers]]")]
    public class HerramientaController : Controller
    {
        private readonly HerramientaService _herramientaService;

        public HerramientaController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ProyectoDBContext>();
            _herramientaService = new HerramientaService(context);
        }
        [HttpGet("obtener-herramientas")]
        public async Task<ActionResult<HerramientasResponse>> GetHerramientas()
        {
            var herramientas = await _herramientaService.ListaHerramientas();

            var response = new HerramientasResponse
            {
                Data = herramientas,
                Code = 200,
                Message = "Herramientas obtenidas correctamente"
            };

            return Ok(response);
        }

        [HttpGet("obtener-herramienta")]
        public async Task<ActionResult<HerramientaResponse>> GetHerramienta(int id)
        {
            var herramienta = await _herramientaService.ObtenerHerramienta(id);

            var response = new HerramientaResponse
            {
                Data = herramienta,
                Code = 200,
                Message = "Herramienta obtenida correctamente"
            };

            return Ok(response);
        }

        [HttpPost("ingresar-herramienta")]
        public async Task<ActionResult<NuevaHerramientaResponse>> PostHerramienta([FromBody] HerramientaDTO herramienta)
        {
            var ingreso = await _herramientaService.IngresarHerramienta(herramienta);

            var response = new NuevaHerramientaResponse
            {
                Data = ingreso,
                Code = 200,
                Message = "Herramienta ingresada correctamente"
            };

            return Ok(response);
        }

    }
}
