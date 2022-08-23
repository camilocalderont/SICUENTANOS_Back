using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class ParametroDetalleConfig
    {
        public ParametroDetalleConfig(EntityTypeBuilder<ParametroDetalle> entity)
        {
            entity.ToTable("ParametroDetalle");

            entity.HasKey(p=> p.Id); 

            entity.HasOne(p => p.Parametro).WithMany(p => p.ParametroDetalle).HasForeignKey(p => p.ParametroId);

            entity.Property(p=> p.VcNombre).IsRequired().HasMaxLength(50);

            entity.Property(p=> p.TxDescripcion).IsRequired(false);

            entity.Property(p=> p.VcCodigoInterno).IsRequired().HasMaxLength(50);

            entity.Property(p=> p.DCodigoIterno).IsRequired(false).HasPrecision(17,3);

            entity.Property(p=> p.BEstado).IsRequired();

            entity.Property(p=> p.RangoDesde).IsRequired(false);

            entity.Property(p=> p.RangoHasta).IsRequired(false);
        }
    }
}