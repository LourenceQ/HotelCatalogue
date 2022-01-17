using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelCatalogue.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93490a09-f9d6-4a5a-87b5-80ab6e20f329", "e3ed4e46-3339-4ac4-91ad-4cbc73dabde1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7563eb0d-ffa7-4307-bb40-23b54ae94c0d", "ad5b2866-cdf4-4a60-b750-8900bc1a29d9", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7563eb0d-ffa7-4307-bb40-23b54ae94c0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93490a09-f9d6-4a5a-87b5-80ab6e20f329");
        }
    }
}
