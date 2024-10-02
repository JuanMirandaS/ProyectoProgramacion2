using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProyectoProgramacion2.Servicio;
using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.Modelo;
namespace ProyectoProgramacion2.Controllers
{
    [ApiController]
    [Route("ProyectoProgramacion2/[Controllers]")]
    public class TareaController : Controller 
    {
        private readonly TareaService _tareaService;

        public TareaController(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ProyectoDBContext>();

        }
    }
}
