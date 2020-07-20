using Microsoft.EntityFrameworkCore.Migrations;

namespace PKWebApp.Migrations
{
    public partial class UpdatedDb101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_CoreServices_CoreServiceId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Tickets_TicketId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_TicketId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CalculatedPrice",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EstimatedBudget",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CoreServiceId",
                table: "Services",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ServiceId",
                table: "Tickets",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CoreServices_CoreServiceId",
                table: "Services",
                column: "CoreServiceId",
                principalTable: "CoreServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Services_ServiceId",
                table: "Tickets",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_CoreServices_CoreServiceId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Services_ServiceId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ServiceId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "CalculatedPrice",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstimatedBudget",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CoreServiceId",
                table: "Services",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_TicketId",
                table: "Services",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CoreServices_CoreServiceId",
                table: "Services",
                column: "CoreServiceId",
                principalTable: "CoreServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Tickets_TicketId",
                table: "Services",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
