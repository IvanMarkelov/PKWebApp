using Microsoft.EntityFrameworkCore.Migrations;

namespace PKWebApp.Migrations
{
    public partial class updatedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoreServices_Ticket_TicketId",
                table: "CoreServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Ticket_TicketId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_CoreServices_TicketId",
                table: "CoreServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ServiceDescription",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "CoreServices");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "ServicePriceTag",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientContactInfoId",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstimatedBudget",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Tickets",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_Services_TicketId",
                table: "Services",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ClientContactInfoId",
                table: "Tickets",
                column: "ClientContactInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tickets_TicketId",
                table: "Orders",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Tickets_TicketId",
                table: "Services",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ClientContacts_ClientContactInfoId",
                table: "Tickets",
                column: "ClientContactInfoId",
                principalTable: "ClientContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tickets_TicketId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Tickets_TicketId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ClientContacts_ClientContactInfoId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "ClientContacts");

            migrationBuilder.DropIndex(
                name: "IX_Services_TicketId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ClientContactInfoId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ServicePriceTag",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ClientContactInfoId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EstimatedBudget",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceDescription",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "CoreServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CoreServices_TicketId",
                table: "CoreServices",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoreServices_Ticket_TicketId",
                table: "CoreServices",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Ticket_TicketId",
                table: "Orders",
                column: "TicketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
