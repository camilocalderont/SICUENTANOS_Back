using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class ModuloConfig
    {
        public ModuloConfig(EntityTypeBuilder<Modulo> entity)
        {
            entity.ToTable("Modulo");

            entity.HasMany(p=> p.Actividades).WithOne();

            entity.HasKey(p=> p.Id); 

            entity.Property(p=> p.VcNombre).IsRequired().HasMaxLength(50);

            entity.Property(p=> p.VcDescripcion).IsRequired().HasMaxLength(200);

            entity.Property(p=> p.VcRedireccion).IsRequired(false).HasMaxLength(80);

             entity.Property(p=> p.VcIcono).IsRequired(false).HasMaxLength(20);

            entity.Property(p=> p.BEstado).IsRequired();

            entity.Property(p=> p.DtFechaCreacion).IsRequired();

            entity.Property(p=> p.DtFechaActualizacion).IsRequired();

            entity
            .Property(p=> p.DtFechaAnulacion)
            .IsRequired()
            .HasComment("Fecha Eliminacion del registro");



             entity.HasData(
                new Modulo
                {
                    Id= Guid.Parse("lah56279-8a6g-3921-b790-7e81f758o0ds"),
                    VcNombre= "Administrador",
                    VcDescripcion= "Modulo para gestionar los permisos de los usuarios dentro del aplicativo",
                    VcIcono= "bi bi-sliders",
                    BEstado= true
                },
                new Modulo
                {
                    Id= Guid.Parse("lah56279-8a6g-3921-b790-7e81f758o0ki"),
                    VcNombre= "Orientación e Información",
                    VcDescripcion= "Modulo para registrar la gestión de orientación e información de la Dirección de Servicio a la Ciudadanía DSC",
                    VcIcono="bi bi-info-circle-fill",
                    BEstado= true
                },
                new Modulo
                {
                    Id= Guid.Parse("lah56279-8a6g-3921-b790-7e81f758o0ju"),
                    VcNombre= "Asistencia Técnica",
                    VcDescripcion= "Modulo para realizar seguimiento a las actividades que cumple el equipo de asistencia técnica tales como planes de acción",
                    VcIcono= "bi bi-search-heart",
                    BEstado= true
                }                                
            );
        }
    }
}