namespace ProyectoProgramacion2.Modelo
{
    public class Herramienta
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Tarea> Tareas { get; set; }
    }
}