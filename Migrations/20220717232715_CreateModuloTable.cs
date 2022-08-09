using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SICUENTANOS_Back.Migrations
{
    public partial class CreateModuloTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VcNombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VcDescricion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VcIcono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Iestado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VcNombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Iestado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    VcDocumento = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    VcPrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcSegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcPrimerApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VcSegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcCorreo = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    VcTelefono = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    VcDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcIdAzure = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VcToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iestado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    VcNombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdPadre = table.Column<int>(type: "int", nullable: false),
                    VcDescricion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VcRedireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VcIcono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iestado = table.Column<bool>(type: "bit", nullable: false),
                    DtFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtFechaAnulacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actividad_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolUsuario",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuario", x => new { x.RolesId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_RolUsuario_Rol_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Usuario_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActividadRol",
                columns: table => new
                {
                    ActividadesId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadRol", x => new { x.ActividadesId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_ActividadRol_Actividad_ActividadesId",
                        column: x => x.ActividadesId,
                        principalTable: "Actividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadRol_Rol_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Modulo",
                columns: new[] { "Id", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "Iestado", "VcDescricion", "VcIcono", "VcNombre" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Modulo para gestionar los permisos de los usuarios dentro del aplicativo", "bi bi-sliders", "Administrador" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Modulo para registrar la gestión de orientación e información de la Dirección de Servicio a la Ciudadanía DSC", "bi bi-info-circle-fill", "Orientación e Información" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Modulo para realizar seguimiento a las actividades que cumple el equipo de asistencia técnica tales como planes de acción", "bi bi-search-heart", "Asistencia Técnica" }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "Iestado", "VcNombre" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Administrador" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Orientación e Información" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Asistencia Técnica" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "Iestado", "TipoDocumentoId", "VcCorreo", "VcDireccion", "VcDocumento", "VcIdAzure", "VcPrimerApellido", "VcPrimerNombre", "VcSegundoApellido", "VcSegundoNombre", "VcTelefono", "VcToken" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, "ldramos@saludcapital.gov.co", null, "1000222333", null, "RAMOS", "LADY", "RAMOS", "DAYANA", "7777777", null });

            migrationBuilder.InsertData(
                table: "Actividad",
                columns: new[] { "Id", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "IdPadre", "Iestado", "ModuloId", "VcDescricion", "VcIcono", "VcNombre", "VcRedireccion" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, true, 1, "", "", "Inicio", "/inicio" });

            migrationBuilder.InsertData(
                table: "Actividad",
                columns: new[] { "Id", "DtFechaActualizacion", "DtFechaAnulacion", "DtFechaCreacion", "IdPadre", "Iestado", "ModuloId", "VcDescricion", "VcIcono", "VcNombre", "VcRedireccion" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, true, 1, "", "", "Tutoriales", "/tutoriales" });

            migrationBuilder.CreateIndex(
                name: "IX_Actividad_ModuloId",
                table: "Actividad",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadRol_RolesId",
                table: "ActividadRol",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_UsuariosId",
                table: "RolUsuario",
                column: "UsuariosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActividadRol");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropTable(
                name: "Actividad");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Modulo");
        }
    }
}
