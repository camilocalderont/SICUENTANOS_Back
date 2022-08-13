using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class RangosGestionConfig
    {
        public RangosGestionConfig(EntityTypeBuilder<RangosGestion> EntityTypeBuilder)
        {
            EntityTypeBuilder.ToTable("RangosGestion");
            EntityTypeBuilder.HasKey(p=> p.Id); 

            EntityTypeBuilder.Property(p=> p.VcNombre).IsRequired().HasMaxLength(100);

            EntityTypeBuilder.Property(p=> p.Porcentaje).IsRequired();

            EntityTypeBuilder.Property(p=> p.VcColor).IsRequired();

            EntityTypeBuilder.Property(p=> p.BEstado).IsRequired();

            EntityTypeBuilder.Property(p=> p.DtFechaCreacion).IsRequired();

            EntityTypeBuilder.Property(p=> p.DtFechaActualizacion).IsRequired();

            EntityTypeBuilder.Property(p=> p.DtFechaEliminacion).IsRequired();
        }
    }
}