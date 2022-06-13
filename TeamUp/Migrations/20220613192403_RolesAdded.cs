using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamUp.Migrations
{
    public partial class RolesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f223698-2bac-4017-942e-a102e0bc02c0", "b544a715-a1d5-4195-b23c-5ce21d1f817f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c53b9a78-ef67-4c40-a627-d24e09086951", "f01643ce-d739-49cc-b0d9-683317fc3811", "Visitor", "VISITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f223698-2bac-4017-942e-a102e0bc02c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c53b9a78-ef67-4c40-a627-d24e09086951");
        }
    }
}
