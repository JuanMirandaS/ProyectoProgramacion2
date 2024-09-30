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
        public async Task<bool> DeleteTarea(int id)
        {
            try
            {
                var tarea = await context.Tarea.FindAsync(id);

                if (tarea == null)
                {
                    return false; // La tarea no fue encontrada
                }

                context.Tarea.Remove(tarea);
                await context.SaveChangesAsync();

                return true; // Tarea eliminada exitosamente
            }
            catch (Exception ex)
            {
                // Manejar el error (logging, etc.)
                return false;
            }
        }
        public async Task<bool> UpdateTarea(Tarea tareaActualizada)
        {
            try
            {
                var tareaExistente = await context.Tarea.FindAsync(tareaActualizada.Id);

                if (tareaExistente == null)
                {
                    return false; // La tarea no fue encontrada
                }

                // Actualizar las propiedades de la tarea existente con los nuevos valores
                tareaExistente.Horas = tareaActualizada.Horas;
                tareaExistente.Area = tareaActualizada.Area;
                tareaExistente.FechaInicio = tareaActualizada.FechaInicio;
                tareaExistente.EstadoTarea = tareaActualizada.EstadoTarea;

                context.Tarea.Update(tareaExistente);
                await context.SaveChangesAsync();

                return true; // Tarea actualizada exitosamente
            }
            catch (Exception ex)
            {
                // Manejar el error (logging, etc.)
                return false;
            }
        }


    }
}
