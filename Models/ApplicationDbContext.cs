using Microsoft.EntityFrameworkCore;
using SICUENTANOS_Back.Models.Administrador;
using SICUENTANOS_Back.Models.Administrador.Config;

namespace SICUENTANOS_Back.Models
{
    public class ApplicationDbContext : DbContext
    {
       public DbSet<Actividad> Actividad { get; set; }

       public DbSet<Modulo> Modulo { get; set;}  

        public DbSet<Configuracion> Configuracion { get; set;}  

        public DbSet<RangosGestion> RangosGestion { get; set;}    

        public DbSet<DiasFestivo> DiasFestivo { get; set;}

        public DbSet<Parametro> Parametro { get; set;} 

        public DbSet<ParametroDetalle> ParametroDetalle { get; set;}

         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ConfiguracionConfig(modelBuilder.Entity<Configuracion>());

            new ModuloConfig(modelBuilder.Entity<Modulo>());

            new ActividadConfig(modelBuilder.Entity<Actividad>());

            new DiasFestivoConfig(modelBuilder.Entity<DiasFestivo>());

            new RangosGestionConfig(modelBuilder.Entity<RangosGestion>());

            new ParametroConfig(modelBuilder.Entity<Parametro>());

             new ParametroDetalleConfig(modelBuilder.Entity<ParametroDetalle>());
        }
               
    }
}