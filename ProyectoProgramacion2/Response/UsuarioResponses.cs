using ProyectoProgramacion2.Modelo;

namespace ProyectoProgramacion2.Response
{
    public class UsuarioResponses
    {
        public class UsuarioResponse : ResponseBase<Usuario>
        {
        }
        public class UsuariosResponse : ResponseBase<List<Usuario>>
        {
        }

        public class NuevoUsuarioResponse : ResponseBase<bool>
        {
        }

    }
}
