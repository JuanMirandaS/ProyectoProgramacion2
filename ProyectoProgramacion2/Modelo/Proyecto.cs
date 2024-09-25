namespace ProyectoProgramacion2.Modelo
{
    public class Proyecto
    {
        public int Id { get; set; }
        public required string Nombre  { get; set; }
        public required string Descripcion { get; set; }
        public required string Estado { get; set; }
        public int HorasTrabajadas { get; set; }
        public required int HorasTotales { get; set; }
        public required DateTime FechaCreacion { get; set; }
    }
}
