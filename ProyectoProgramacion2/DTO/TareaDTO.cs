using System.ComponentModel.DataAnnotations;

namespace ProyectoProgramacion2.DTO
{
    public class TareaDTO
    {
        [Required(ErrorMessage = "El estado de la tarea es requerido.")]
        [RegularExpression("^(Pendiente|En progreso|Finalizado)$", ErrorMessage = "El estado ingresado no es válido.")]
        
        public string EstadoTarea { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Las horas trabajadas deben ser al menos 1.")]
        public int Horas { get; set; }

        [Required(ErrorMessage = "El área es requerida.")]
        [RegularExpression("^(Hardware|Redes)$", ErrorMessage = "El área ingresada no es válida.")]
        public string Area { get; set; }

        [Required(ErrorMessage = "El proyecto es requerido.")]
        public int ProyectoID { get; set; }

        [Required(ErrorMessage = "El usuario es requerido.")]
        public int UsuarioID { get; set; }
        
        public string SetHerramientas { get; set; }
    }
}
