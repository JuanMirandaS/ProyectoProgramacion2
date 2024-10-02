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
        public async Task<bool> ActualizarProyecto(int id,ProyectoDTO proyectoDTO)
        {
            try
            {
                // Busca la tarea existente por su ID
                var proyectoExistente = await context.Proyecto.FindAsync(id);
                if (proyectoExistente == null)
                {
                    return false; // La tarea no existe
                }

                // Actualiza las propiedades de la tarea existente
                proyectoExistente.Nombre = proyectoDTO.Nombre ?? proyectoExistente.Nombre; // Se puede mantener el valor anterior si es nulo
                proyectoExistente.Descripcion = proyectoDTO.Descripcion;
                proyectoExistente.Estado = proyectoDTO.Estado;
                proyectoExistente.HorasTotales = proyectoDTO.HorasTotales;
               
                // Guarda los cambios en la base de datos
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Registra el error en un logger o la consola
                Console.WriteLine($"Error al actualizar el proyecto: {ex.Message}");
                return false; // Manejo de errores
            }
        }
        public async Task<bool> EliminarProyecto(int id)
        {
            try
            {
                // Busca la tarea por su ID
                var proyectoExistente = await context.Proyecto.FindAsync(id);
                if (proyectoExistente == null)
                {
                    return false; // La tarea no existe
                }
                // Elimina la tarea encontrada
                context.Proyecto.Remove(proyectoExistente);

                // Guarda los cambios en la base de datos
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Registra el error
                Console.WriteLine($"Error al eliminar el proyecto: {ex.Message}");
                return false; // Manejo de errores
            }
        }
    }
}
