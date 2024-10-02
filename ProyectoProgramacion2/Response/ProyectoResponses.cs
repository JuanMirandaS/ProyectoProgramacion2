using ProyectoProgramacion2.Modelo;

namespace ProyectoProgramacion2.Response
{
    public class ProyectoResponses
    {
        public class ProyectoResponse : ResponseBase<Proyecto>
        {
        }

        public class ProyectosResponse : ResponseBase<List<Proyecto>>
        {
        }

        public class NuevoProyectoResponse : ResponseBase<bool>
        {
        }
    }
}
