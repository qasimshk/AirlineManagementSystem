using Microsoft.EntityFrameworkCore.Migrations;

namespace airline.orchestrator.service.Persistence.Migrations
{
    public partial class AddTicketNumberColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TicketNumber",
                table: "ServiceTransactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketNumber",
                table: "ServiceTransactions");
        }
    }
}
