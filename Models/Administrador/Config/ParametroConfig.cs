using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class ParametroConfig
    {
        public ParametroConfig(EntityTypeBuilder<Parametro> entity)
        {
            entity.ToTable("Parametro");

            entity.HasKey(p=> p.Id); 

            entity.Property(p=> p.VcNombre).IsRequired().HasMaxLength(50);

            entity.Property(p=> p.VcCodigoInterno).IsRequired().HasMaxLength(20);

            entity.Property(p=> p.BEstado).IsRequired();

            entity.Property(p=> p.DtFechaCreacion).IsRequired();

            entity.Property(p=> p.DtFechaActualizacion).IsRequired();

            entity.Property(p=> p.DtFechaAnulacion).IsRequired(false);

        }
    }
}