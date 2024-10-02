using Microsoft.AspNetCore.Mvc;
using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.Servicio;

namespace ProyectoProgramacion2.Controllers
{

    [ApiController]
    [Route("ProyectoProgramacion2/[Controllers]")]
    public class RolController : Controller
    {
        private readonly RolService _rolService;

        public RolController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ProyectoDBContext>();

        }



    }
}
