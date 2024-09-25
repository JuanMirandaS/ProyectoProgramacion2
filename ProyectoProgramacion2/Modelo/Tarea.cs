namespace ProyectoProgramacion2.Modelo
{
    public class Tarea
    {
        public int Id { get; set; }

        public DateTime FechaInicio { get; set; }

        public string EstadoTarea { get; set; }

        public int Horas { get; set; }

        public string Area { get; set; }

        public int IdProyecto { get; set; }

        public int IdEmpleado { get; set; }

    }
}
