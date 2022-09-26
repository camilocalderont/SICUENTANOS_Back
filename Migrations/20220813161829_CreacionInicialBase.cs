using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SICUENTANOS_Back.Migrations
{
    public partial class CreacionInicialBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDiasLimiteRespuesta = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    BSabadoLaboral = table.Column<bool>(type: "bit", nullable: false),
                    BDomingoLaboral = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiasFestivo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DtFecha = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    VcDescripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasFestivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VcDescripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VcRedireccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    VcIcono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha Eliminacion del registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VcCodigoInterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RangosGestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Porcentaje = table.Column<double>(type: "float", nullable: false),
                    VcColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaEliminacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RangosGestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModuloId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VcDescripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VcRedireccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    VcIcono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    PadreId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true, comment: "Id de la actividad padre de acuerdo con la jerarquia"),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha anulación del registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividad_Modulo",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParametroDetalle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParametroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TxDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcCodigoInterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DCodigoIterno = table.Column<decimal>(type: "decimal(17,3)", precision: 17, scale: 3, nullable: false),
                    BEstado = table.Column<bool>(type: "bit", nullable: false),
                    RangoDesde = table.Column<int>(type: "int", nullable: false),
                    RangoHasta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametroDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParametroDetalle_Parametro_ParametroId",
                        column: x => x.ParametroId,
                        principalTable: "Parametro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Modulo",
                columns: new[] { "Id", "BEstado", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "VcDescripcion", "VcIcono", "VcNombre", "VcRedireccion" },
                values: new object[] { new Guid("3246a53f-e88e-45cf-ad93-a5083714f2c6"), true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), "Modulo para realizar seguimiento a las actividades que cumple el equipo de asistencia técnica tales como planes de acción", "bi bi-search-heart", "Asistencia Técnica", null });

            migrationBuilder.InsertData(
                table: "Modulo",
                columns: new[] { "Id", "BEstado", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "VcDescripcion", "VcIcono", "VcNombre", "VcRedireccion" },
                values: new object[] { new Guid("60751df3-44f7-4da9-9a98-9b85aa39a8c4"), true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), "Modulo para gestionar los permisos de los usuarios dentro del aplicativo", "bi bi-sliders", "Administrador", null });

            migrationBuilder.InsertData(
                table: "Modulo",
                columns: new[] { "Id", "BEstado", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "VcDescripcion", "VcIcono", "VcNombre", "VcRedireccion" },
                values: new object[] { new Guid("b000f22f-b327-4cc8-afce-1ec3e1a9217f"), true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), "Modulo para registrar la gestión de orientación e información de la Dirección de Servicio a la Ciudadanía DSC", "bi bi-info-circle-fill", "Orientación e Información", null });

            migrationBuilder.InsertData(
                table: "Actividad",
                columns: new[] { "Id", "BEstado", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "ModuloId", "PadreId", "VcDescripcion", "VcIcono", "VcNombre", "VcRedireccion" },
                values: new object[,]
                {
                    { new Guid("136e80b6-663e-42d3-bc36-b63463f4ed88"), true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), new Guid("60751df3-44f7-4da9-9a98-9b85aa39a8c4"), "b235b97e-e79a-481a-ad19-cb314e5e8ea7", "Gestión de Cargos", "", "Cargos", "/cargos" },
                    { new Guid("651fb52a-eff0-4ba8-8639-8eb415cd177f"), true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), new Guid("60751df3-44f7-4da9-9a98-9b85aa39a8c4"), null, "Configuración General", "bi bi-person-rolodex", "Configuración", "#" },
                    { new Guid("7102d0db-d846-488e-b485-a6518aeb722d"), true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), new Guid("60751df3-44f7-4da9-9a98-9b85aa39a8c4"), "b235b97e-e79a-481a-ad19-cb314e5e8ea7", "Gestión de Áreas", "", "Áreas", "#" },
                    { new Guid("9f8333eb-c849-4db5-9147-7fee695d507c"), true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), new Guid("60751df3-44f7-4da9-9a98-9b85aa39a8c4"), null, "Gestión de roles", "bi bi-person-rolodex", "Roles", "/actividad" },
                    { new Guid("b235b97e-e79a-481a-ad19-cb314e5e8ea7"), true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), new Guid("60751df3-44f7-4da9-9a98-9b85aa39a8c4"), null, "Gestión de personas", "bi bi-person", "Personas", "#" },
                    { new Guid("efaf2845-3c4e-44b1-9385-29781eb7247d"), true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), new Guid("60751df3-44f7-4da9-9a98-9b85aa39a8c4"), "b235b97e-e79a-481a-ad19-cb314e5e8ea7", "Gestión de Puntos de Atención", "bi bi-person", "Puntos de Atención", "#" },
                    { new Guid("f1de5c86-a834-44e6-96fd-d5f7eb2c1565"), true, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), null, new DateTime(2022, 8, 13, 11, 15, 9, 749, DateTimeKind.Local).AddTicks(9773), new Guid("60751df3-44f7-4da9-9a98-9b85aa39a8c4"), "b235b97e-e79a-481a-ad19-cb314e5e8ea7", "Gestión de usuarios", "", "Uusarios", "/usuario" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_ModuloId",
                table: "Actividad",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ParametroDetalle_ParametroId",
                table: "ParametroDetalle",
                column: "ParametroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Configuracion");

            migrationBuilder.DropTable(
                name: "DiasFestivo");

            migrationBuilder.DropTable(
                name: "ParametroDetalle");

            migrationBuilder.DropTable(
                name: "RangosGestion");

            migrationBuilder.DropTable(
                name: "Modulo");

            migrationBuilder.DropTable(
                name: "Parametro");
        }
    }
}
