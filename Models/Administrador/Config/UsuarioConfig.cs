using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class UsuarioConfig
    {
        public UsuarioConfig(EntityTypeBuilder<Usuario> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x=>x.TipoDocumentoId).IsRequired();
            entityTypeBuilder.Property(x=>x.VcDocumento).IsRequired().HasMaxLength(25);
            entityTypeBuilder.Property(x=>x.VcPrimerApellido).IsRequired().HasMaxLength(50);
            entityTypeBuilder.Property(x=>x.VcPrimerApellido).IsRequired().HasMaxLength(50);
            entityTypeBuilder.Property(x=>x.VcCorreo).IsRequired().HasMaxLength(80);
            entityTypeBuilder.Property(x=>x.VcTelefono).IsRequired().HasMaxLength(25);
            entityTypeBuilder.Property(x=>x.VcIdAzure).HasMaxLength(500);
            entityTypeBuilder.Property(x=>x.Iestado).IsRequired();
            //entityTypeBuilder.Property(x=>x.DtFechaCreacion).HasDefaultValueSql("getdate()");

            entityTypeBuilder.HasData(
                new Usuario
                {
                    Id=1,
                    TipoDocumentoId=1,
                    VcDocumento="1000222333",
                    VcPrimerNombre="LADY",
                    VcSegundoNombre="DAYANA",
                    VcPrimerApellido="RAMOS",
                    VcSegundoApellido="RAMOS",
                    VcCorreo="ldramos@saludcapital.gov.co",
                    VcTelefono="7777777",
                    Iestado=true
                }                             
            );
        }
    }
}