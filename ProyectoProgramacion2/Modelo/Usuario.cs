using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoProgramacion2.Modelo
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public ICollection<Tarea> Tareas { get; set; }

 

    }
}
