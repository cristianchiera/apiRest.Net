using ApiRestEjemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRestEjemplo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public DbSet<Operacion> Operaciones { get; set; }
        public DbSet<SujetoActividad> SujetoActividad { get; set; } // <-- Agrega esta línea
        public DbSet<RelacionTipo> RelacionTipo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SujetoActividad>().ToTable("sujeto_actividad_id");
            modelBuilder.Entity<RelacionTipo>().HasKey(rt => rt.relacion_tipo_id);
        }
    }
}