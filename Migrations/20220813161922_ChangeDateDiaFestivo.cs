using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SICUENTANOS_Back.Migrations
{
    public partial class ChangeDateDiaFestivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DtFecha",
                table: "DiasFestivo",
                type: "Date",
                nullable: false
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DtFecha",
                table: "DiasFestivo",
                nullable: false
            );
        }
    }
}
