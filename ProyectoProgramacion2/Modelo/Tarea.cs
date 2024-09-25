namespace ProyectoProgramacion2.Modelo
{
    public class Tarea
    {
        public int idTarea { get; set; }

        public DateTime fechaInicio { get; set; }

        public string estadoTarea { get; set; }

        public int horas { get; set; }

        public string area { get; set; }

        public int idProyecto { get; set; }

        public int idEmpleado { get; set; }

    }
}
