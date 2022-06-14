using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamUp.Migrations
{
    public partial class SeedBaseUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b982c35-4c20-4fb0-891a-cc02e7fe30fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cae3e7e3-599f-4a84-9472-860fdb9c1b41");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4225e79b-688c-4f38-ae2c-b1b6d4dce7ab", "4225e79b-688c-4f38-ae2c-b1b6d4dce7ab", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4af8fe0a-c109-41a3-a9aa-82cf40c65d89", "4af8fe0a-c109-41a3-a9aa-82cf40c65d89", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "78759c27-9e8c-43d7-8375-6e930734b592", 0, "1957d0a3-c8b6-4838-8111-1a7e5af9f17d", "nathjcollins@gmail.com", true, false, null, "NATHJCOLLINS@GMAIL.COM", "CENTYPOO", "AQAAAAEAACcQAAAAEARBITrC7FzV/Qkhl5EwT6U1ZIyUkobUidsKXkz8EKBKfsgMlmYyawI+IHsH4kmKEA==", null, false, "40cd6d4e-fcaa-4cf6-b20d-46bbdd582464", false, "CentyPoo" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4af8fe0a-c109-41a3-a9aa-82cf40c65d89", "78759c27-9e8c-43d7-8375-6e930734b592" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4225e79b-688c-4f38-ae2c-b1b6d4dce7ab");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4af8fe0a-c109-41a3-a9aa-82cf40c65d89", "78759c27-9e8c-43d7-8375-6e930734b592" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4af8fe0a-c109-41a3-a9aa-82cf40c65d89");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "78759c27-9e8c-43d7-8375-6e930734b592");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b982c35-4c20-4fb0-891a-cc02e7fe30fa", "ddcd8fab-64a4-4af4-9f92-eaa84b8028db", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cae3e7e3-599f-4a84-9472-860fdb9c1b41", "9f402f73-b343-4cec-ac44-073d3953d993", "Admin", "ADMIN" });
        }
    }
}
