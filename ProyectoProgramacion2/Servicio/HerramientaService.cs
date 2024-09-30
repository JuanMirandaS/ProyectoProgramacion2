using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.Modelo;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacion2.Servicio
{
    public class HerramientaService
    {
        private readonly ProyectoDBContext context;

        public HerramientaService(ProyectoDBContext _context)
        {
            context = _context;
        }
        public async Task<List<Herramienta>> ListaTareas()
        {
            List<Herramienta> herramientas = await context.Herramienta.ToListAsync();
            return herramientas;
        }
        public async Task<Herramienta> ObtenerHerramienta(int id)
        {
            Herramienta herramienta = await context.Herramienta.FindAsync(id);
            return herramienta;
        }
        public async Task<bool> IngresarHerramienta(Herramienta herramienta)
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
        public async Task<bool> DeleteHerramienta(int id)
        {
            try
            {
                var herramienta = await context.Herramienta.FindAsync(id);

                if ( herramienta == null)
                {
                    return false; // La herramienta no fue encontrada
                }

                context.Herramienta.Remove(herramienta);
                await context.SaveChangesAsync();

                return true; // Herramienta eliminada exitosamente
            }
            catch (Exception ex)
            {
                // Manejar el error (logging, etc.)
                return false;
            }
        }
        public async Task<bool> UpdateHerramienta(Herramienta herramientaActualizada)
        {
            try
            {
                var herramientaExistente = await context.Herramienta.FindAsync(herramientaActualizada.Id);

                if (herramientaExistente == null)
                {
                    return false; // La herramienta no fue encontrada
                }

                // Actualizar las propiedades de la herramienta existente con los nuevos valores
                herramientaExistente.Nombre = herramientaActualizada.Nombre;
            

                context.Herramienta.Update(herramientaExistente);
                await context.SaveChangesAsync();

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
