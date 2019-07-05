using Microsoft.EntityFrameworkCore.Migrations;

namespace Serita.Data.Migrations
{
    public partial class AddView_LanguagesRefShared : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string script = @"  CREATE VIEW Serita.LanguagesRefShared
                                AS  
                                SELECT L.Id, L.Title, L.Code
                                FROM Shared.Languages as L";
            migrationBuilder.Sql(script);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string script = @"DROP VIEW Serita.LanguagesRefShared";
            migrationBuilder.Sql(script);
        }
    }
}
