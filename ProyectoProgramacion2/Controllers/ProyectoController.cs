using Microsoft.AspNetCore.Mvc;
using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.Servicio;

namespace ProyectoProgramacion2.Controllers
{
    [ApiController]
    [Route("ProyectoProgramacion2/[Controllers]")]
    public class ProyectoController : Controller
    {
        private readonly ProyectoService _proyectoService;
        public ProyectoController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ProyectoDBContext>();

        }

    }
}
