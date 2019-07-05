using Microsoft.EntityFrameworkCore.Migrations;

namespace Serita.Data.Migrations
{
    public partial class AddView_MenuItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string script = @"  CREATE VIEW Serita.MenuItems
                                AS  
                                SELECT MV.Id, MT.LanguageId, MV.ParentId, MT.Title, MV.IconName, MV.IsDefault, MV.IsChecked, MV.HasSeparator, MV.Link, MV.ShortCut, MV.Ordering
                                FROM Serita.MenuItemValues AS MV INNER JOIN Serita.MenuItemTitles AS MT ON MV.Id = MT.Id";
            migrationBuilder.Sql(script);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string script = @"DROP VIEW Serita.MenuItems";
            migrationBuilder.Sql(script);
        }
    }
}
