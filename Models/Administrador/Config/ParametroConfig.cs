using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class ParametroConfig
    {
        public ParametroConfig(EntityTypeBuilder<Parametro> EntityTypeBuilder)
        {
            EntityTypeBuilder.ToTable("Parametro");

            EntityTypeBuilder.HasKey(p=> p.Id); 

            EntityTypeBuilder.Property(p=> p.VcNombre).IsRequired().HasMaxLength(50);

            EntityTypeBuilder.Property(p=> p.VcCodigoInterno).IsRequired().HasMaxLength(20);

            EntityTypeBuilder.Property(p=> p.BEstado).IsRequired();

            EntityTypeBuilder.Property(p=> p.DtFechaCreacion).IsRequired();

            EntityTypeBuilder.Property(p=> p.DtFechaActualizacion).IsRequired();

        }
    }
}