using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamUp.Migrations
{
    public partial class FixUserIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGameProfiles_AspNetUsers_UserId1",
                table: "UserGameProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPositions_AspNetUsers_UserId1",
                table: "UserPositions");

            migrationBuilder.DropIndex(
                name: "IX_UserPositions_UserId1",
                table: "UserPositions");

            migrationBuilder.DropIndex(
                name: "IX_UserGameProfiles_UserId1",
                table: "UserGameProfiles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f223698-2bac-4017-942e-a102e0bc02c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c53b9a78-ef67-4c40-a627-d24e09086951");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserPositions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserGameProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserPositions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserGameProfiles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bc544027-8bc8-4fe7-a09a-96577188dc79", "9e4c94e3-68ec-46e2-a5f6-dd55fccfb811", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f17d9116-860c-4728-aba9-5dd62c6a7add", "c8c47b0a-5dc5-455e-a141-8905d96fcd6a", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_UserPositions_UserId",
                table: "UserPositions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameProfiles_UserId",
                table: "UserGameProfiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameProfiles_AspNetUsers_UserId",
                table: "UserGameProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPositions_AspNetUsers_UserId",
                table: "UserPositions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGameProfiles_AspNetUsers_UserId",
                table: "UserGameProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPositions_AspNetUsers_UserId",
                table: "UserPositions");

            migrationBuilder.DropIndex(
                name: "IX_UserPositions_UserId",
                table: "UserPositions");

            migrationBuilder.DropIndex(
                name: "IX_UserGameProfiles_UserId",
                table: "UserGameProfiles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc544027-8bc8-4fe7-a09a-96577188dc79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f17d9116-860c-4728-aba9-5dd62c6a7add");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserPositions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserPositions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserGameProfiles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserGameProfiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0f223698-2bac-4017-942e-a102e0bc02c0", "b544a715-a1d5-4195-b23c-5ce21d1f817f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c53b9a78-ef67-4c40-a627-d24e09086951", "f01643ce-d739-49cc-b0d9-683317fc3811", "Visitor", "VISITOR" });

            migrationBuilder.CreateIndex(
                name: "IX_UserPositions_UserId1",
                table: "UserPositions",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameProfiles_UserId1",
                table: "UserGameProfiles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGameProfiles_AspNetUsers_UserId1",
                table: "UserGameProfiles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPositions_AspNetUsers_UserId1",
                table: "UserPositions",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
