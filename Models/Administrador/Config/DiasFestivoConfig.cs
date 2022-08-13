using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class DiasFestivoConfig
    {
        public DiasFestivoConfig(EntityTypeBuilder<DiasFestivo> EntityTypeBuilder)
        {
            EntityTypeBuilder.ToTable("DiasFestivo");
            EntityTypeBuilder.HasKey(p=> p.Id); 

            EntityTypeBuilder.Property(p=> p.DtFecha).IsRequired().HasMaxLength(100);

            EntityTypeBuilder.Property(p=> p.VcDescripcion).IsRequired().HasMaxLength(50);

            EntityTypeBuilder.Property(p=> p.DtFechaCreacion).IsRequired();

            EntityTypeBuilder.Property(p=> p.DtFechaActualizacion).IsRequired();

            EntityTypeBuilder.Property(p=> p.DtFechaEliminacion).IsRequired();
        }
    }
}