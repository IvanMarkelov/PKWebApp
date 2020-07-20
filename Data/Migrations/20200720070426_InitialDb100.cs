using Microsoft.EntityFrameworkCore.Migrations;

namespace PKWebApp.Migrations
{
    public partial class InitialDb100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(nullable: true),
                    ClientEmail = table.Column<string>(nullable: true),
                    ClientPhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoreServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoreServiceTitle = table.Column<string>(nullable: true),
                    CoreServicDescription = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoreServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(nullable: true),
                    EstimatedBudget = table.Column<int>(nullable: false),
                    CalculatedPrice = table.Column<int>(nullable: false),
                    ClientContactInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_ClientContacts_ClientContactInfoId",
                        column: x => x.ClientContactInfoId,
                        principalTable: "ClientContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTitle = table.Column<string>(nullable: true),
                    ServicePriceTag = table.Column<int>(nullable: false),
                    CoreServiceId = table.Column<int>(nullable: false),
                    TicketId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_CoreServices_CoreServiceId",
                        column: x => x.CoreServiceId,
                        principalTable: "CoreServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_CoreServiceId",
                table: "Services",
                column: "CoreServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_TicketId",
                table: "Services",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ClientContactInfoId",
                table: "Tickets",
                column: "ClientContactInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "CoreServices");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "ClientContacts");
        }
    }
}
