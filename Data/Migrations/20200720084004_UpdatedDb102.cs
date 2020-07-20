using Microsoft.EntityFrameworkCore.Migrations;

namespace PKWebApp.Migrations
{
    public partial class UpdatedDb102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoreServicDescription",
                table: "CoreServices");

            migrationBuilder.AddColumn<string>(
                name: "CoreServiceDescription",
                table: "CoreServices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoreServiceDescription",
                table: "CoreServices");

            migrationBuilder.AddColumn<string>(
                name: "CoreServicDescription",
                table: "CoreServices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
