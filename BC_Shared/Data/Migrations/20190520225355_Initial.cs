using Microsoft.EntityFrameworkCore.Migrations;

namespace Shared.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Shared");

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "Shared",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 32, nullable: false),
                    Code = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusValues",
                schema: "Shared",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusTitles",
                schema: "Shared",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTitles", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_StatusTitles_StatusValues_Id",
                        column: x => x.Id,
                        principalSchema: "Shared",
                        principalTable: "StatusValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatusTitles_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Shared",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatusTitles_LanguageId",
                schema: "Shared",
                table: "StatusTitles",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusTitles",
                schema: "Shared");

            migrationBuilder.DropTable(
                name: "StatusValues",
                schema: "Shared");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "Shared");
        }
    }
}
