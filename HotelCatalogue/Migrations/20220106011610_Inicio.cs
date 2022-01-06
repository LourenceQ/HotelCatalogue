using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelCatalogue.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7283f33f-5400-4dd0-b2e7-914551160377");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9637748-c032-4dd9-bf9f-97971692288c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49370866-62c8-43db-83cf-7cb567bcf0d0", "76db3e89-0fca-4cd2-8b16-9d8044217827", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "81dd2a83-0640-403a-b1a1-e135d1a77d6e", "4134d758-8359-4f2d-a324-67d572794cdc", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49370866-62c8-43db-83cf-7cb567bcf0d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81dd2a83-0640-403a-b1a1-e135d1a77d6e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7283f33f-5400-4dd0-b2e7-914551160377", "a5c615d1-5829-4e9d-adcc-e36d38808f99", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9637748-c032-4dd9-bf9f-97971692288c", "ee1f6a4d-b025-4c21-9177-33e91df1b5f3", "Administrator", "ADMINISTRATOR" });
        }
    }
}
