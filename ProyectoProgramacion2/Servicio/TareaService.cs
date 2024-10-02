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
        public async Task<bool> ActualizarTarea(int id, TareaDTO tareaDTO)
        {
            try
            {
                // Busca la tarea existente por su ID
                var tareaExistente = await context.Tarea.FindAsync(id);
                if (tareaExistente == null)
                {
                    return false; // La tarea no existe
                }

                // Actualiza las propiedades de la tarea existente
                tareaExistente.EstadoTarea = tareaDTO.EstadoTarea ?? tareaExistente.EstadoTarea; // Se puede mantener el valor anterior si es nulo
                tareaExistente.Horas = tareaDTO.Horas;
                tareaExistente.Area = tareaDTO.Area;
                tareaExistente.ProyectoID = tareaDTO.ProyectoID;
                tareaExistente.UsuarioID = tareaDTO.UsuarioID;
                tareaExistente.SetHerramientas = tareaDTO.SetHerramientas ?? tareaExistente.SetHerramientas; // Se puede mantener el valor anterior si es nulo

                // Guarda los cambios en la base de datos
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Registra el error en un logger o la consola
                Console.WriteLine($"Error al actualizar la tarea: {ex.Message}");
                return false; // Manejo de errores
            }
        }
        public async Task<bool> EliminarTarea(int id)
        {
            try
            {
                // Busca la tarea por su ID
                var tareaExistente = await context.Tarea.FindAsync(id);
                if (tareaExistente == null)
                {
                    return false; // La tarea no existe
                }

                // Elimina la tarea encontrada
                context.Tarea.Remove(tareaExistente);

                // Guarda los cambios en la base de datos
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Registra el error
                Console.WriteLine($"Error al eliminar la tarea: {ex.Message}");
                return false; // Manejo de errores
            }
        }

    }
}
