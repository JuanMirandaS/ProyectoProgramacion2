using ProyectoProgramacion2.Modelo;

namespace ProyectoProgramacion2.Response
{
    public class TareaResponses
    {
        public class TareaResponse : ResponseBase<Tarea>
        {
        }

        /*retorna una lista de tareas*/
        public class TareasResponse : ResponseBase<List<Tarea>>
        {
        }

        public class NuevaTareaResponse : ResponseBase<bool>
        {
        }
    }
}
