using ProyectoProgramacion2.Modelo;

namespace ProyectoProgramacion2.Response
{
    public class HerramientaResponses
    {
        public class HerramientaResponse : ResponseBase<Herramienta>
        {
        }
        public class HerramientasResponse : ResponseBase<List<Herramienta>>
        {
        }
        public class NuevaHerramientaResponse : ResponseBase<bool>
        {
        }
    }
}
