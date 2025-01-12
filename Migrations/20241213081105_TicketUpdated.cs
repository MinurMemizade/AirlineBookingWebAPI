using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirlineBookingWebApi.Migrations
{
    /// <inheritdoc />
    public partial class TicketUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPasssengers",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPasssengers",
                table: "Ticket");
        }
    }
}
