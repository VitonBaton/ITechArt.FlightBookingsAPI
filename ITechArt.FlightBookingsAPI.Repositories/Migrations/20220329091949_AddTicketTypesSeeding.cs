using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITechArt.FlightBookingsAPI.Infrastructure.Migrations
{
    public partial class AddTicketTypesSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "Economy" });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), "Business" });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), "Deluxe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));
        }
    }
}
