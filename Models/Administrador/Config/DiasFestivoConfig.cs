using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class DiasFestivoConfig
    {
        public DiasFestivoConfig(EntityTypeBuilder<DiasFestivo> entity)
        {
            entity.ToTable("DiasFestivo");
            entity.HasKey(p=> p.Id); 

            entity.Property(p=> p.DtFecha).IsRequired().HasMaxLength(100);

            entity.Property(p=> p.VcDescripcion).IsRequired(false).HasMaxLength(50);

            entity.Property(p=> p.DtFechaCreacion).IsRequired();

            entity.Property(p=> p.DtFechaActualizacion).IsRequired();

            entity.Property(p=> p.DtFechaAnulacion).IsRequired(false);
        }
    }
}