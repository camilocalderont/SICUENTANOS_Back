using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class ParametroDetalleConfig
    {
        public ParametroDetalleConfig(EntityTypeBuilder<ParametroDetalle> EntityTypeBuilder)
        {
            EntityTypeBuilder.ToTable("ParametroDetalle");

            EntityTypeBuilder.HasKey(p=> p.Id); 

            EntityTypeBuilder.HasOne(p => p.Parametro).WithMany(p => p.ParametroDetalle).HasForeignKey(p => p.ParametroId);

            EntityTypeBuilder.Property(p=> p.VcNombre).IsRequired().HasMaxLength(50);

             EntityTypeBuilder.Property(p=> p.TxDescripcion).IsRequired(false);

            EntityTypeBuilder.Property(p=> p.VcCodigoInterno).IsRequired().HasMaxLength(50);

            EntityTypeBuilder.Property(p=> p.DCodigoIterno).IsRequired().HasPrecision(17,3);

            EntityTypeBuilder.Property(p=> p.BEstado).IsRequired();

            EntityTypeBuilder.Property(p=> p.RangoDesde).IsRequired();

            EntityTypeBuilder.Property(p=> p.RangoHasta).IsRequired();
        }
    }
}