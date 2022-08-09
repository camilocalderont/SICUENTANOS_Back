using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class ModuloConfig
    {
        public ModuloConfig(EntityTypeBuilder<Modulo> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x=>x.VcNombre).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(x=>x.VcDescricion).IsRequired().HasMaxLength(500);
            entityTypeBuilder.Property(x=>x.VcIcono).IsRequired().HasMaxLength(50);
            entityTypeBuilder.Property(x=>x.Iestado).IsRequired();
            //entityTypeBuilder.Property(x=>x.DtFechaCreacion).HasDefaultValueSql("getdate()");

            entityTypeBuilder.HasData(
                new Modulo
                {
                    Id=1,
                    VcNombre="Administrador",
                    VcDescricion="Modulo para gestionar los permisos de los usuarios dentro del aplicativo",
                    VcIcono="bi bi-sliders",
                    Iestado=true
                },
                new Modulo
                {
                    Id=2,
                    VcNombre="Orientación e Información",
                    VcDescricion="Modulo para registrar la gestión de orientación e información de la Dirección de Servicio a la Ciudadanía DSC",
                    VcIcono="bi bi-info-circle-fill",
                    Iestado=true
                },
                new Modulo
                {
                    Id=3,
                    VcNombre="Asistencia Técnica",
                    VcDescricion="Modulo para realizar seguimiento a las actividades que cumple el equipo de asistencia técnica tales como planes de acción",
                    VcIcono="bi bi-search-heart",
                    Iestado=true
                }                                
            );
        }
    }
}