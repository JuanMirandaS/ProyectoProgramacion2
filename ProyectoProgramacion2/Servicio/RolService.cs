using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.Modelo;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacion2.Servicio
{
    public class RolService
    {
        private readonly ProyectoDBContext context;

        public RolService(ProyectoDBContext _context)
        {
            context = _context;
        }
        public async Task<List<Rol>> ListaRol()
        {
            List<Rol> roles = await context.Rol.ToListAsync();
            return roles;
        }
        public async Task<Rol> ObtenerRol(int id)
        {
            Rol rol = await context.Rol.FindAsync(id);
            return rol;

        }
    }
}
