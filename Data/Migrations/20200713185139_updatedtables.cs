using Microsoft.EntityFrameworkCore.Migrations;

namespace PKWebApp.Migrations
{
    public partial class updatedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PKServices_Ticket_TicketId",
                table: "PKServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_PKServices_CoreServiceId",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PKServices",
                table: "PKServices");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "PKServices",
                newName: "CoreServices");

            migrationBuilder.RenameIndex(
                name: "IX_Service_CoreServiceId",
                table: "Services",
                newName: "IX_Services_CoreServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_PKServices_TicketId",
                table: "CoreServices",
                newName: "IX_CoreServices_TicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoreServices",
                table: "CoreServices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoreServices_Ticket_TicketId",
                table: "CoreServices",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CoreServices_CoreServiceId",
                table: "Services",
                column: "CoreServiceId",
                principalTable: "CoreServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoreServices_Ticket_TicketId",
                table: "CoreServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_CoreServices_CoreServiceId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoreServices",
                table: "CoreServices");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "CoreServices",
                newName: "PKServices");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CoreServiceId",
                table: "Service",
                newName: "IX_Service_CoreServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_CoreServices_TicketId",
                table: "PKServices",
                newName: "IX_PKServices_TicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PKServices",
                table: "PKServices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PKServices_Ticket_TicketId",
                table: "PKServices",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_PKServices_CoreServiceId",
                table: "Service",
                column: "CoreServiceId",
                principalTable: "PKServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
