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
        public string SetHerramientas { get; set; }
        [ForeignKey("Proyecto")]
        public int ProyectoID { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioID{ get; set; }
    }
}
