using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamUp.Migrations
{
    public partial class AddUserGameProfilePosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_UserGameProfiles_UserGameProfileId",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "UserPositions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_UserGameProfileId",
                table: "Positions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc544027-8bc8-4fe7-a09a-96577188dc79");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f17d9116-860c-4728-aba9-5dd62c6a7add");

            migrationBuilder.DropColumn(
                name: "UserGameProfileId",
                table: "Positions");

            migrationBuilder.CreateTable(
                name: "UserGameProfilePositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    UserGameProfileId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGameProfilePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGameProfilePositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGameProfilePositions_UserGameProfiles_UserGameProfileId",
                        column: x => x.UserGameProfileId,
                        principalTable: "UserGameProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b982c35-4c20-4fb0-891a-cc02e7fe30fa", "ddcd8fab-64a4-4af4-9f92-eaa84b8028db", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cae3e7e3-599f-4a84-9472-860fdb9c1b41", "9f402f73-b343-4cec-ac44-073d3953d993", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_UserGameProfilePositions_PositionId",
                table: "UserGameProfilePositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameProfilePositions_UserGameProfileId",
                table: "UserGameProfilePositions",
                column: "UserGameProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGameProfilePositions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b982c35-4c20-4fb0-891a-cc02e7fe30fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cae3e7e3-599f-4a84-9472-860fdb9c1b41");

            migrationBuilder.AddColumn<int>(
                name: "UserGameProfileId",
                table: "Positions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPositions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bc544027-8bc8-4fe7-a09a-96577188dc79", "9e4c94e3-68ec-46e2-a5f6-dd55fccfb811", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f17d9116-860c-4728-aba9-5dd62c6a7add", "c8c47b0a-5dc5-455e-a141-8905d96fcd6a", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_UserGameProfileId",
                table: "Positions",
                column: "UserGameProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPositions_PositionId",
                table: "UserPositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPositions_UserId",
                table: "UserPositions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_UserGameProfiles_UserGameProfileId",
                table: "Positions",
                column: "UserGameProfileId",
                principalTable: "UserGameProfiles",
                principalColumn: "Id");
        }
    }
}
