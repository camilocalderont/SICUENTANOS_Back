using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class ActividadConfig
    {
        public ActividadConfig(EntityTypeBuilder<Actividad> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x=>x.VcNombre).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property(x=>x.VcDescricion).IsRequired().HasMaxLength(500);
            entityTypeBuilder.Property(x=>x.ModuloId).IsRequired();
            entityTypeBuilder.Property(x=>x.Iestado).IsRequired();
            entityTypeBuilder.HasKey(x=>x.Id);
            entityTypeBuilder
                .HasOne(x=>x.Modulo)
                .WithMany(m=>m.Actividades)
                .HasForeignKey(x=>x.ModuloId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);            

            entityTypeBuilder.HasData(
                new Actividad
                {
                    Id=1,
                    VcNombre="Inicio",
                    VcDescricion="",
                    VcIcono="",
                    VcRedireccion="/inicio",
                    Iestado=true,
                    ModuloId=1
                },
                new Actividad
                {
                    Id=2,
                    VcNombre="Tutoriales",
                    VcDescricion="",
                    VcIcono="",
                    VcRedireccion="/tutoriales",
                    Iestado=true,
                    ModuloId=1
                }                              
            );
        }
    }
}