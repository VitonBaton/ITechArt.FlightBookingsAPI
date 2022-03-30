using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITechArt.FlightBookingsAPI.Infrastructure.Migrations
{
    public partial class ChangedGuidsForTicketTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { new Guid("2a223348-e2ae-4a9d-9670-c2de1b909d38"), "Business" });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { new Guid("be6efb48-2df0-495d-bfc0-77040e66ab8d"), "Economy" });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[] { new Guid("e5023336-e00d-4c2d-a095-3cf3d589d998"), "Deluxe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: new Guid("2a223348-e2ae-4a9d-9670-c2de1b909d38"));

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: new Guid("be6efb48-2df0-495d-bfc0-77040e66ab8d"));

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: new Guid("e5023336-e00d-4c2d-a095-3cf3d589d998"));

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
    }
}
