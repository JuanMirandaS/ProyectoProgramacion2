using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoProgramacion2.Modelo
{
    public class Tarea
    {
        public int Id { get; set; }

        public DateTime FechaInicio { get; set; }

        public string EstadoTarea { get; set; }

        public int Horas { get; set; }

        public string Area { get; set; }

        [ForeignKey("Proyecto")]
        public int IdProyecto { get; set; }

        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }

    }
}
