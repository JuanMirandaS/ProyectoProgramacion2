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
        public async Task<List<Usuario>> ObtenerUsuariosPorRol(int rolId)
        {
            var rol = await context.Rol
                .Include(r => r.Usuarios) // Incluye la colección de usuarios
                .FirstOrDefaultAsync(r => r.Id == rolId);

            if (rol == null)
            {
                return null; // O lanza una excepción si lo prefieres
            }

            return rol.Usuarios.ToList(); // Devuelve la lista de usuarios asociados al rol
        }

    }
}
