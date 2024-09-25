using Microsoft.EntityFrameworkCore;
using ProyectoProgramacion2.Modelo;

namespace ProyectoProgramacion2.Data
{
    public class ProyectoDBContext : DbContext
    {
        public ProyectoDBContext(DbContextOptions<ProyectoDBContext> options) : base(options)
        {
        }

        /* DbSet indica el modelo que se va a mapear (reflejar) a la base de datos */
        public DbSet<Rol> Rol { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Tarea> Tarea { get; set; }

        public DbSet<Proyecto> Proyecto { get; set; }
        
        public DbSet<Herramienta> Herramienta { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Acá se pueden cargar los datos iniciales de la base de datos

            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Nombre = "Administrador"
            });

            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 2,
                Nombre = "Empleado"
            });

        }

    }
}
