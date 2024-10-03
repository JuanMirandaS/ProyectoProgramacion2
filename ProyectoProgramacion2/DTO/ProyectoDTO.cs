using System.ComponentModel.DataAnnotations;

namespace ProyectoProgramacion2.DTO
{
    public class ProyectoDTO
    {

        [Required(ErrorMessage = "El nombre del proyecto es obligatorio.")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado del proyecto es obligatorio.")]
        [RegularExpression("^(Activo|Inactivo|Finalizado)$", ErrorMessage = "El estado debe ser Activo, Inactivo o Finalizado.")]
        public string Estado { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Las horas trabajadas deben ser 0 al ingresarse.")]
        public int HorasTotales { get; set; }
    }
}
