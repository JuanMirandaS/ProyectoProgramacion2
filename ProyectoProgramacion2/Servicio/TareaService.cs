using Microsoft.EntityFrameworkCore;
using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.Modelo;
namespace ProyectoProgramacion2.Servicio
{
    public class TareaService
    {
        private readonly ProyectoDBContext context;

        public TareaService(ProyectoDBContext _context)
        {
            context = _context;
        }
        public async Task<List<Tarea>> ListaTareas()
        {
            List<Tarea> tareas = await context.Tarea.ToListAsync();
            return tareas;  
        }
        public async Task<Tarea> ObtenerTarea(int id)
        {
            Tarea tarea = await context.Tarea.FindAsync(id);
            return tarea;
        }
        public async Task<bool> IngresarTarea(Tarea tarea)
        {

            try
            {
                var nuevaTarea = new Tarea
                {
                 
                    FechaInicio = DateTime.Now,
                    
                    EstadoTarea = "Pendiente",
                   
                };

                context.Tarea.Add(nuevaTarea);

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
