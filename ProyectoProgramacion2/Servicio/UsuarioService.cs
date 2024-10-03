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
                // Verifica si el rol existe antes de ingresar el usuario
                var rolExistente = await context.Rol.FindAsync(usuario.RolId);
                if (rolExistente == null)
                {
                    throw new ArgumentException($"El rol con ID {usuario.RolId} no existe.");
                }

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
        public async Task<bool> ActualizarUsuario(int id, UsuarioDTO usuarioDTO)
        {
            try
            {
                // Busca el usuario existente por su ID
                var usuarioExistente = await context.Usuario.FindAsync(id);
                if (usuarioExistente == null)
                {
                    return false; // El usuario no existe
                }

                // Actualiza las propiedades del usuario existente
                usuarioExistente.Nombre = usuarioDTO.Nombre ?? usuarioExistente.Nombre; // Se puede mantener el valor anterior si es nulo
                usuarioExistente.Password = usuarioDTO.Password;
                usuarioExistente.Email = usuarioDTO.Email;
                usuarioExistente.RolId = usuarioDTO.RolId;

                // Guarda los cambios en la base de datos
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Registra el error en un logger o la consola
                Console.WriteLine($"Error al actualizar el usuario: {ex.Message}");
                return false; // Manejo de errores
            }
        }

        public async Task<bool> EliminarUsuario(int id)
        {
            try
            {
                // Busca el usuario por su ID
                var usuarioExistente = await context.Usuario.FindAsync(id);
                if (usuarioExistente == null)
                {
                    return false; // El usuario no existe
                }

                // Elimina el usuario encontrado
                context.Usuario.Remove(usuarioExistente);

                // Guarda los cambios en la base de datos
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Registra el error
                Console.WriteLine($"Error al eliminar el usuario: {ex.Message}");
                return false; // Manejo de errores
            }
        }

    }
}
