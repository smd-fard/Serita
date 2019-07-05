using Microsoft.EntityFrameworkCore.Migrations;

namespace Shared.Data.Migrations
{
    public partial class AddView_Statuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string script =
                @"  CREATE VIEW Shared.Statuses
                    AS  
                    SELECT S.Id, ST.LanguageId, ST.Title, S.IsDefault
                    FROM Shared.StatusValues AS S INNER JOIN Shared.StatusTitles AS ST ON S.Id = St.Id";
            migrationBuilder.Sql(script);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string script = @"DROP VIEW Shared.Statuses";
            migrationBuilder.Sql(script);
        }
    }
}
