using Microsoft.EntityFrameworkCore;
using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.Modelo;
using ProyectoProgramacion2.DTO;
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
        public async Task<bool> IngresarTarea(TareaDTO tarea)
        {

            try
            {
                var nuevaTarea = new Tarea
                {
                    FechaInicio = DateTime.Now,
                    EstadoTarea = tarea.EstadoTarea,
                    Horas = tarea.Horas,
                    Area = tarea.Area,
                    ProyectoID = tarea.ProyectoID,
                    UsuarioID = tarea.UsuarioID,
                    SetHerramientas = tarea.SetHerramientas

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
