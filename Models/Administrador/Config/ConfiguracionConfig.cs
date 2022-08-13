using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class ConfiguracionConfig
    {
        public ConfiguracionConfig(EntityTypeBuilder<Configuracion> EntityTypeBuilder)
        {
            EntityTypeBuilder.ToTable("Configuracion");
            EntityTypeBuilder.HasKey(p=> p.Id); 

            EntityTypeBuilder.Property(p=> p.IDiasLimiteRespuesta).IsRequired().HasMaxLength(100);

            EntityTypeBuilder.Property(p=> p.BDomingoLaboral).IsRequired().HasMaxLength(50);

            EntityTypeBuilder.Property(p=> p.BEstado).IsRequired();

            EntityTypeBuilder.Property(p=> p.DtFechaCreacion).IsRequired();

            EntityTypeBuilder.Property(p=> p.DtFechaActualizacion).IsRequired();

            EntityTypeBuilder.Property(p=> p.DtFechaEliminacion).IsRequired();
        }
    }
}