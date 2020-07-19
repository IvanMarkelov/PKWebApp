using Microsoft.EntityFrameworkCore.Migrations;

namespace PKWebApp.Migrations
{
    public partial class PKUpdatedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PKServices_Ticket_TicketId",
                table: "PKServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_PKServices_CoreServiceId",
                table: "Service");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PKServices",
                table: "PKServices");

            migrationBuilder.DropIndex(
                name: "IX_PKServices_TicketId",
                table: "PKServices");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServiceDescription",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "PKServices");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

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

            migrationBuilder.AddColumn<int>(
                name: "CalculatedPrice",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AlterColumn<int>(
                name: "CoreServiceId",
                table: "Services",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServicePriceTag",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Services",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoreServices",
                table: "CoreServices",
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
                name: "IX_Tickets_ClientContactInfoId",
                table: "Tickets",
                column: "ClientContactInfoId");

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
                name: "FK_Services_CoreServices_CoreServiceId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Tickets_TicketId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ClientContacts_ClientContactInfoId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "ClientContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ClientContactInfoId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_TicketId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoreServices",
                table: "CoreServices");

            migrationBuilder.DropColumn(
                name: "CalculatedPrice",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ClientContactInfoId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EstimatedBudget",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ServicePriceTag",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CoreServiceId",
                table: "Service",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Service",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceDescription",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "PKServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PKServices",
                table: "PKServices",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PKServices_TicketId",
                table: "PKServices",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TicketId",
                table: "Orders",
                column: "TicketId");

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
