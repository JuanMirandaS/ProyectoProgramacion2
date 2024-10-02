using Microsoft.AspNetCore.Mvc;
using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.Modelo;
using ProyectoProgramacion2.Servicio;

using static ProyectoProgramacion2.Response.RolResponses;

namespace ProyectoProgramacion2.Controllers
{

    [ApiController]
    [Route("ProyectoProgramacion2/[[Controllers]]")]
    public class RolController : Controller
    {
        private readonly RolService _rolService;

        public RolController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ProyectoDBContext>();
            _rolService = new RolService(context);
        }
        [HttpGet("obtener-roles")]
        public async Task<ActionResult<UsuariosPorRolResponse>> GetUsuarios(int id)
        {
            var roles = await _rolService.ObtenerUsuariosPorRol(id);

            var response = new UsuariosPorRolResponse
            {
                Data = roles,
                Code = 200,
                Message = "Usuarios por rol obtenidos correctamente"
            };

            return Ok(response);
        }


    }
}
