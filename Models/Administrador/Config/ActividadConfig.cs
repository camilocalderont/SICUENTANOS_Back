using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SICUENTANOS_Back.Models.Administrador.Config
{
    public class ActividadConfig
    {
        public ActividadConfig(EntityTypeBuilder<Actividad> entity)
        {
            entity.ToTable("Actividad");

            entity.HasKey(p=> p.Id); 

            entity
            .HasOne(p => p.Modulo)
            .WithMany(p => p.Actividades)
            .HasForeignKey(p => p.ModuloId)
            .HasConstraintName("FK_Actividad_Modulo");

            entity.Property(p=> p.VcNombre).IsRequired().HasMaxLength(50);

            entity.Property(p=> p.VcDescripcion).IsRequired().HasMaxLength(200);

            entity.Property(p=> p.VcRedireccion).IsRequired().HasMaxLength(80);

            entity.Property(p=> p.VcIcono).IsRequired().HasMaxLength(20);

            entity.Property(p=> p.BEstado).IsRequired();

            entity.Property(p=> p.DtFechaCreacion).IsRequired();

            entity.Property(p=> p.DtFechaActualizacion).IsRequired();

            entity
            .Property(p=> p.DtFechaAnulacion)
            .IsRequired()
            .HasComment("Fecha anulación del registro");



            entity.HasData(
                new Actividad
                {
                    Id= Guid.Parse("dad11219-4e2b-4149-a571-2e70b945effc"),
                    ModuloId = Guid.Parse("lah56279-8a6g-3921-b790-7e81f758o0ki"),
                    VcNombre = "Inicio",
                    VcDescripcion = "Descripción de prueba",
                    VcRedireccion = "/inicio",
                    VcIcono = "Prueba ",
                    BEstado = true,
                    DtFechaCreacion= DateTime.Now,
                    DtFechaActualizacion= DateTime.Now
                },
                new Actividad
                {
                    Id= Guid.Parse("dad11219-4e2b-4149-a571-2e70b945efefa"),
                    ModuloId= Guid.Parse("lah56279-8a6g-3921-b790-7e81f758o0ds"),
                    VcNombre = "Prueba",
                    VcDescripcion = "Descripcion numero dos de prueba",
                    VcRedireccion = "/pruebadeinicio",
                    VcIcono = "Prueba 2",
                    BEstado = true,
                    DtFechaCreacion= DateTime.Now,
                    DtFechaActualizacion= DateTime.Now
                }                              
            );
        }
    }
}