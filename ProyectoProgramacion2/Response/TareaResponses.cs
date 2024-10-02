using ProyectoProgramacion2.Modelo;

namespace ProyectoProgramacion2.Response
{
    public class TareaResponses
    {
        public class TareaResponse : ResponseBase<Tarea>
        {
        }
        public class TareasResponse : ResponseBase<List<Tarea>>
        {
        }
        public class NuevaTareaResponse : ResponseBase<bool>
        {
        }
        public class ActualizarTareaResponse : ResponseBase<bool>
        {

        }
        public class EliminarTareaResponse : ResponseBase<bool>
        {

        }
    }
}
