using ProyectoProgramacion2.Data;
using ProyectoProgramacion2.DTO;
using ProyectoProgramacion2.Modelo;
using Microsoft.EntityFrameworkCore;

namespace ProyectoProgramacion2.Servicio
{
    public class UsuarioService
    {
        private readonly ProyectoDBContext context;

        public UsuarioService(ProyectoDBContext _context)
        {
            context = _context;
        }

        public async Task<List<Usuario>> ListaUsuarios()
        {
            List<Usuario> usuarios = await context.Usuario.ToListAsync();
            return usuarios;
        }

        public async Task<Usuario> ObtenerUsuario(int id)
        {
            Usuario usuario = await context.Usuario.FindAsync(id);
            return usuario;
        }

        public async Task<bool> IngresarUsuario(UsuarioDTO usuario)
        {
            try
            {
                var nuevoUsuario = new Usuario
                {
                    Nombre = usuario.Nombre,
                    Password = usuario.Password,
                    Email = usuario.Email,
                    RolId = usuario.RolId,
                };

                context.Usuario.Add(nuevoUsuario); 

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
