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
            .HasConstraintName("FK_Actividad_Modulo")
            .OnDelete(DeleteBehavior.Restrict);

            entity.Property(p=> p.VcNombre).IsRequired().HasMaxLength(50);

            entity.Property(p=> p.VcDescripcion).IsRequired().HasMaxLength(200);

            entity.Property(p=> p.VcRedireccion).IsRequired().HasMaxLength(80);

            entity.Property(p=> p.VcIcono).IsRequired().HasMaxLength(20);

            entity.Property(p=> p.BEstado).IsRequired();

            entity.Property(p=> p.PadreId)
            .IsRequired(false)
            .HasMaxLength(40)
            .HasComment("Id de la actividad padre de acuerdo con la jerarquia");

            entity.Property(p=> p.DtFechaCreacion).IsRequired();

            entity.Property(p=> p.DtFechaActualizacion).IsRequired();

            entity
            .Property(p=> p.DtFechaAnulacion)
            .IsRequired(false)
            .HasComment("Fecha anulación del registro");


            
            entity.HasData(
                new Actividad
                {
                    Id= Guid.Parse("b235b97e-e79a-481a-ad19-cb314e5e8ea7"),
                    ModuloId = Guid.Parse("60751df3-44f7-4da9-9a98-9b85aa39a8c4"),
                    VcNombre = "Personas",
                    VcDescripcion = "Gestión de personas",
                    VcRedireccion = "#",
                    VcIcono = "bi bi-person",
                    BEstado = true,
                    DtFechaCreacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    DtFechaActualizacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773)
                },
                new Actividad
                {
                    Id= Guid.Parse("9f8333eb-c849-4db5-9147-7fee695d507c"),
                    ModuloId= Guid.Parse("60751df3-44f7-4da9-9a98-9b85aa39a8c4"),
                    VcNombre = "Roles",
                    VcDescripcion = "Gestión de roles",
                    VcRedireccion = "/actividad",
                    VcIcono = "bi bi-person-rolodex",
                    BEstado = true,
                    DtFechaCreacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    DtFechaActualizacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773)
                },
                new Actividad
                {
                    Id= Guid.Parse("651fb52a-eff0-4ba8-8639-8eb415cd177f"),
                    ModuloId= Guid.Parse("60751df3-44f7-4da9-9a98-9b85aa39a8c4"),
                    VcNombre = "Configuración",
                    VcDescripcion = "Configuración General",
                    VcRedireccion = "#",
                    VcIcono = "bi bi-person-rolodex",
                    BEstado = true,
                    DtFechaCreacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    DtFechaActualizacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773)
                },
                new Actividad
                {
                    Id= Guid.Parse("f1de5c86-a834-44e6-96fd-d5f7eb2c1565"),
                    ModuloId = Guid.Parse("60751df3-44f7-4da9-9a98-9b85aa39a8c4"),
                    VcNombre = "Uusarios",
                    VcDescripcion = "Gestión de usuarios",
                    VcRedireccion = "/usuario",
                    VcIcono = "",
                    BEstado = true,                    
                    DtFechaCreacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    DtFechaActualizacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    PadreId = "b235b97e-e79a-481a-ad19-cb314e5e8ea7"
                    
                }, 
                new Actividad
                {
                    Id= Guid.Parse("136e80b6-663e-42d3-bc36-b63463f4ed88"),
                    ModuloId = Guid.Parse("60751df3-44f7-4da9-9a98-9b85aa39a8c4"),
                    VcNombre = "Cargos",
                    VcDescripcion = "Gestión de Cargos",
                    VcRedireccion = "/cargos",
                    VcIcono = "",
                    BEstado = true,
                    DtFechaCreacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    DtFechaActualizacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    PadreId = "b235b97e-e79a-481a-ad19-cb314e5e8ea7"
                },
                new Actividad
                {
                    Id= Guid.Parse("7102d0db-d846-488e-b485-a6518aeb722d"),
                    ModuloId = Guid.Parse("60751df3-44f7-4da9-9a98-9b85aa39a8c4"),
                    VcNombre = "Áreas",
                    VcDescripcion = "Gestión de Áreas",
                    VcRedireccion = "#",
                    VcIcono = "",
                    BEstado = true,
                    DtFechaCreacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    DtFechaActualizacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    PadreId = "b235b97e-e79a-481a-ad19-cb314e5e8ea7"
                },
                new Actividad
                {
                    Id= Guid.Parse("efaf2845-3c4e-44b1-9385-29781eb7247d"),
                    ModuloId = Guid.Parse("60751df3-44f7-4da9-9a98-9b85aa39a8c4"),
                    VcNombre = "Puntos de Atención",
                    VcDescripcion = "Gestión de Puntos de Atención",
                    VcRedireccion = "#",
                    VcIcono = "bi bi-person",
                    BEstado = true,
                    DtFechaCreacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    DtFechaActualizacion= new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773),
                    PadreId = "b235b97e-e79a-481a-ad19-cb314e5e8ea7"
                }                                                                                          
            );
            
        }
    }
}