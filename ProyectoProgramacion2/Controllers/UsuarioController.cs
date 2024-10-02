
using Microsoft.AspNetCore.Mvc;
using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.Servicio;

namespace ProyectoProgramacion2.Controllers
{

    [ApiController]
    [Route("ProyectoProgramacion2/[Controllers]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ProyectoDBContext>();

        }

    }
}
