using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestTaskApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestTaskApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<byte>(type: "smallint", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleDbUserDb",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleDbUserDb", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleDbUserDb_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleDbUserDb_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" },
                    { 3, "Support" },
                    { 4, "SuperAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name" },
                values: new object[,]
                {
                    { 1, (byte)18, "IamOlivia@gmail.com", "Olivia" },
                    { 2, (byte)21, "Samuel1@gmail.com", "Samuel" },
                    { 3, (byte)23, "Harry_Harry@gmail.com", "Harry" },
                    { 4, (byte)48, "tTthomas@gmail.com", "Thomas" },
                    { 5, (byte)11, "DavidDD@gmail.com", "David" },
                    { 6, (byte)33, "SophiaABC@gmail.com", "Sophia" },
                    { 7, (byte)27, "LilyYy@gmail.com", "Lily" },
                    { 8, (byte)30, "Scarlett@gmail.com", "Scarlett" },
                    { 9, (byte)19, "charlieee@gmail.com", "Charlie" },
                    { 10, (byte)22, "1connor1@gmail.com", "Connor" },
                    { 11, (byte)21, "Ssstanley@gmail.com", "Stanley" },
                    { 12, (byte)29, "Lora123@gmail.com", "Lora" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleDbUserDb_UsersId",
                table: "RoleDbUserDb",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Title",
                table: "Roles",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleDbUserDb");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
