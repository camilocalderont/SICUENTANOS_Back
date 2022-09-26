using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SICUENTANOS_Back.Migrations
{
    public partial class ChangeTableNameRangoGestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RangosGestion",
                newName: "RangoGestion"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RangoGestion",
                newName: "RangosGestion"
            );
        }
    }
}
