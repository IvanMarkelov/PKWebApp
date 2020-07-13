using Microsoft.EntityFrameworkCore.Migrations;

namespace PKWebApp.Migrations
{
    public partial class newtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "PKServices");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PKServices");

            migrationBuilder.AddColumn<string>(
                name: "CoreServicDescription",
                table: "PKServices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoreServiceTitle",
                table: "PKServices",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTitle = table.Column<string>(nullable: true),
                    ServiceDescription = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    CoreServiceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_PKServices_CoreServiceId",
                        column: x => x.CoreServiceId,
                        principalTable: "PKServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_CoreServiceId",
                table: "Service",
                column: "CoreServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropColumn(
                name: "CoreServicDescription",
                table: "PKServices");

            migrationBuilder.DropColumn(
                name: "CoreServiceTitle",
                table: "PKServices");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "PKServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PKServices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
