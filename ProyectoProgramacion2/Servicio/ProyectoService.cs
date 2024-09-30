using ProyectoProgramacion2.Data;
using Microsoft.EntityFrameworkCore;
using ProyectoProgramacion2.Modelo;

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
        /*public async Task<bool> IngresarProyecto(Proyecto proyecto)
        {

          
            

        }*/
        public async Task<bool> DeleteProyecto(int id)
        {
            try
            {
                var proyecto = await context.Proyecto.FindAsync(id);

                if (proyecto == null)
                {
                    return false; // La herramienta no fue encontrada
                }

                context.Proyecto.Remove(proyecto);
                await context.SaveChangesAsync();

                return true; // Herramienta eliminada exitosamente
            }
            catch (Exception ex)
            {
                // Manejar el error (logging, etc.)
                return false;
            }
        }
        public async Task<bool> UpdateProyecto(Proyecto proyectoActualizado)
        {
            try
            {
                var proyectoExistente = await context.Proyecto.FindAsync(proyectoActualizado.Id);

                if (proyectoExistente == null)
                {
                    return false; // La herramienta no fue encontrada
                }

                //Rellenar este metodo las propiedades de la herramienta existente con los nuevos valores
              

                return true; // Herramienta actualizada exitosamente
            }
            catch (Exception ex)
            {
                // Manejar el error (logging, etc.)
                return false;
            }
        }
    }
}
