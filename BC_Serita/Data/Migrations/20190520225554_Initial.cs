using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Serita.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Serita");

            migrationBuilder.CreateTable(
                name: "MenuItemValues",
                schema: "Serita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    IconName = table.Column<string>(maxLength: 32, nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    HasSeparator = table.Column<bool>(nullable: false),
                    ShortCut = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true),
                    IsChecked = table.Column<bool>(nullable: false),
                    Link = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true),
                    Ordering = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItemValues_MenuItemValues_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Serita",
                        principalTable: "MenuItemValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemTitles",
                schema: "Serita",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemTitles", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_MenuItemTitles_MenuItemValues_Id",
                        column: x => x.Id,
                        principalSchema: "Serita",
                        principalTable: "MenuItemValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                        name: "FK_MenuItemTitles_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Shared",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);                        
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemValues_ParentId",
                schema: "Serita",
                table: "MenuItemValues",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItemTitles",
                schema: "Serita");

            migrationBuilder.DropTable(
                name: "MenuItemValues",
                schema: "Serita");
        }
    }
}
