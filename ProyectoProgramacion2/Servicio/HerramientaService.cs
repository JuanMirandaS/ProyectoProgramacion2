using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.Modelo;
using Microsoft.EntityFrameworkCore;
using ProyectoProgramacion2.DTO;
namespace ProyectoProgramacion2.Servicio
{
    public class HerramientaService
    {
        private readonly ProyectoDBContext context;

        public HerramientaService(ProyectoDBContext _context)
        {
            context = _context;
        }
        public async Task<List<Herramienta>> ListaHerramientas()
        {
            List<Herramienta> herramientas = await context.Herramienta.ToListAsync();
            return herramientas;
        }
        public async Task<Herramienta> ObtenerHerramienta(int id)
        {
            Herramienta herramienta = await context.Herramienta.FindAsync(id);
            return herramienta;
        }
        public async Task<bool> IngresarHerramienta(HerramientaDTO herramienta)
        {

            try
            {
                var nuevaHerramienta = new Herramienta
                {

                    Nombre = herramienta.Nombre

                };

                context.Herramienta.Add(nuevaHerramienta);

                await context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        public async Task<bool> ActualizarHerramienta(int id, HerramientaDTO herramientaDTO)
        {
            try
            {
                // Busca la herramienta existente por su ID
                var herramientaExistente = await context.Herramienta.FindAsync(id);
                if (herramientaExistente == null)
                {
                    return false; // La herramienta no existe
                }

                // Actualiza las propiedades de la herramienta existente
                herramientaExistente.Nombre = herramientaDTO.Nombre ?? herramientaExistente.Nombre; // Se puede mantener el valor anterior si es nulo
          

                // Guarda los cambios en la base de datos
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Registra el error en un logger o la consola
                Console.WriteLine($"Error al actualizar la herramienta: {ex.Message}");
                return false; // Manejo de errores
            }
        }

        public async Task<bool> EliminarHerramienta(int id)
        {
            try
            {
                // Busca la herramienta por su ID
                var herramientaExistente = await context.Herramienta.FindAsync(id);
                if (herramientaExistente == null)
                {
                    return false; // La herramienta no existe
                }

                // Elimina la herramienta encontrada
                context.Herramienta.Remove(herramientaExistente);

                // Guarda los cambios en la base de datos
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Registra el error
                Console.WriteLine($"Error al eliminar la herramienta: {ex.Message}");
                return false; // Manejo de errores
            }
        }





    }
}
