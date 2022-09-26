using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class RangosGestionConfig
    {
        public RangosGestionConfig(EntityTypeBuilder<RangosGestion> entity)
        {
            entity.ToTable("RangosGestion");
            entity.HasKey(p=> p.Id); 

            entity.Property(p=> p.VcNombre).IsRequired().HasMaxLength(100);

            entity.Property(p=> p.Porcentaje).IsRequired();

            entity.Property(p=> p.VcColor).IsRequired();

            entity.Property(p=> p.BEstado).IsRequired();

            entity.Property(p=> p.DtFechaCreacion).IsRequired();

            entity.Property(p=> p.DtFechaActualizacion).IsRequired();

            entity.Property(p=> p.DtFechaEAnulacion).IsRequired(false);
        }
    }
}