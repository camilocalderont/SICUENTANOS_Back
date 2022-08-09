using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class RolConfig
    {
        public RolConfig(EntityTypeBuilder<Rol> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x=>x.VcNombre).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(x=>x.Iestado).IsRequired();
            //entityTypeBuilder.Property(x=>x.DtFechaCreacion).HasDefaultValueSql("getdate()");

            entityTypeBuilder.HasData(
                new Rol
                {
                    Id=1,
                    VcNombre="Administrador",
                    Iestado=true
                },
                new Rol
                {
                    Id=2,
                    VcNombre="Orientación e Información",
                    Iestado=true
                },
                new Rol
                {
                    Id=3,
                    VcNombre="Asistencia Técnica",
                    Iestado=true
                }                                
            );
        }
    }
}