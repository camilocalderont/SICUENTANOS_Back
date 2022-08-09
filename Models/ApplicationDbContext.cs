using Microsoft.EntityFrameworkCore;
using SICUENTANOS_Back.Models.Administrador;
using SICUENTANOS_Back.Models.Administrador.Config;

namespace SICUENTANOS_Back.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        } 

        public DbSet<Modulo> Modulo { get; set;}
        public DbSet<Actividad> Actividad { get; set;} 
        public DbSet<Rol> Rol { get; set;}    
        public DbSet<Usuario> Usuario { get; set;}    


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ModuloConfig(modelBuilder.Entity<Modulo>());
            new ActividadConfig(modelBuilder.Entity<Actividad>());
            new RolConfig(modelBuilder.Entity<Rol>());
            new UsuarioConfig(modelBuilder.Entity<Usuario>());
        }
               
    }
}