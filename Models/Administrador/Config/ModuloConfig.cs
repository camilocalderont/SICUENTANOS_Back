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

             entity.Property(p=> p.VcIcono).IsRequired(false).HasMaxLength(50);

            entity.Property(p=> p.BEstado).IsRequired();

            entity.Property(p=> p.DtFechaCreacion).IsRequired();

            entity.Property(p=> p.DtFechaActualizacion).IsRequired();

            entity
            .Property(p=> p.DtFechaAnulacion)
            .IsRequired(false)
            .HasComment("Fecha Eliminacion del registro");



             entity.HasData(
                new Modulo
                {
                    Id= Guid.Parse("60751df3-44f7-4da9-9a98-9b85aa39a8c4"),
                    VcNombre= "Administrador",
                    VcDescripcion= "Modulo para gestionar los permisos de los usuarios dentro del aplicativo",
                    VcIcono= "bi bi-sliders",
                    BEstado= true,
                    DtFechaCreacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    DtFechaActualizacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773)                    
                },
                new Modulo
                {
                    Id= Guid.Parse("b000f22f-b327-4cc8-afce-1ec3e1a9217f"),
                    VcNombre= "Orientación e Información",
                    VcDescripcion= "Modulo para registrar la gestión de orientación e información de la Dirección de Servicio a la Ciudadanía DSC",
                    VcIcono="bi bi-info-circle-fill",
                    BEstado= true,
                    DtFechaCreacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    DtFechaActualizacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773)  
                },
                new Modulo
                {
                    Id= Guid.Parse("3246a53f-e88e-45cf-ad93-a5083714f2c6"),
                    VcNombre= "Asistencia Técnica",
                    VcDescripcion= "Modulo para realizar seguimiento a las actividades que cumple el equipo de asistencia técnica tales como planes de acción",
                    VcIcono= "bi bi-search-heart",
                    BEstado= true,
                    DtFechaCreacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    DtFechaActualizacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773)
                }                                
            );
        }
    }
}