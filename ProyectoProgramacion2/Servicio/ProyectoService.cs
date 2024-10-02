using ProyectoProgramacion2.Data;
using Microsoft.EntityFrameworkCore;
using ProyectoProgramacion2.Modelo;
using System.Threading;
using ProyectoProgramacion2.DTO;
namespace ProyectoProgramacion2.Servicio
{
    public class ProyectoService
    {
        private readonly ProyectoDBContext context;
        public ProyectoService(ProyectoDBContext _context)
        {
            context = _context;
        }
        public async Task<List<Proyecto>> ListaProyecto()
        {
            List<Proyecto> proyectos = await context.Proyecto.ToListAsync();
            return proyectos;
        }
        public async Task<Proyecto> ObtenerProyecto(int id)
        {
            Proyecto proyecto = await context.Proyecto.FindAsync(id);
            return proyecto;
        }
        public async Task<bool> IngresarProyecto(ProyectoDTO proyecto)
        {
            try
            {
                var nuevoProyecto = new Proyecto
                {
                    Nombre = proyecto.Nombre,
                    Descripcion = proyecto.Descripcion,
                    Estado = proyecto.Estado,
                    HorasTotales = proyecto.HorasTotales


                };

                context.Proyecto.Add(nuevoProyecto);

                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }




        }

    }
}
