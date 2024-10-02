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





    }
}
