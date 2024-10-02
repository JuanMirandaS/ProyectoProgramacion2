
using Microsoft.AspNetCore.Mvc;
using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.DTO;
using ProyectoProgramacion2.Servicio;
using static ProyectoProgramacion2.Response.ProyectoResponses;
using static ProyectoProgramacion2.Response.UsuarioResponses;

namespace ProyectoProgramacion2.Controllers
{

    [ApiController]
    [Route("ProyectoProgramacion2/[[Controllers]]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ProyectoDBContext>();
            _usuarioService = new UsuarioService(context);
        }
        [HttpGet("obtener-usuarios")]
        public async Task<ActionResult<UsuariosResponse>> GetUsuarios()
        {
            var usuarios = await _usuarioService.ListaUsuarios();

            var response = new UsuariosResponse
            {
                Data = usuarios,
                Code = 200,
                Message = "Usuarios obtenidos correctamente"
            };

            return Ok(response);
        }

        [HttpGet("obtener-usuario")]
        public async Task<ActionResult<UsuarioResponse>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.ObtenerUsuario(id);

            var response = new UsuarioResponse
            {
                Data = usuario,
                Code = 200,
                Message = "Usuario obtenido correctamente"
            };

            return Ok(response);
        }

        [HttpPost("ingresar-usuario")]
        public async Task<ActionResult<NuevoUsuarioResponse>> PostUsuario([FromBody] UsuarioDTO usuario)
        {
            var ingreso = await _usuarioService.IngresarUsuario(usuario);

            var response = new NuevoUsuarioResponse
            {
                Data = ingreso,
                Code = 200,
                Message = "Usuario ingresado correctamente"
            };

            return Ok(response);
        }
        [HttpPut("actualizar-usuario/{id}")]
        public async Task<ActionResult<ActualizarUsuarioResponse>> UpdateUsuario(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            var resultado = await _usuarioService.ActualizarUsuario(id, usuarioDTO);
            var response = new ActualizarUsuarioResponse
            {
                Data = resultado,
                Code = 200,
                Message = "Usuario actualizado correctamente"
            };
            return Ok(response);
        }

        [HttpDelete("eliminar-usuario/{id}")]
        public async Task<ActionResult<EliminarUsuarioResponse>> DeleteUsuario(int id)
        {
            var resultado = await _usuarioService.EliminarUsuario(id);
            var response = new EliminarUsuarioResponse
            {
                Data = resultado,
                Code = 200,
                Message = "Usuario eliminado correctamente"
            };

            return Ok(response); // 200 si el usuario fue eliminado correctamente
        }

    }
}
