using Microsoft.EntityFrameworkCore.Migrations;

namespace Serita.Data.Migrations
{
    public partial class Seed_MenuItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string script =
                @"INSERT INTO Serita.MenuItemValues([Id], [IconName], [IsDefault], [ParentId], [HasSeparator], [ShortCut], [IsChecked], [Link], [Ordering]) VALUES(10, null, 1, null, 0, null, 0, '/', 0)" +
                "INSERT INTO Serita.MenuItemValues([Id], [IconName], [IsDefault], [ParentId], [HasSeparator], [ShortCut], [IsChecked], [Link], [Ordering]) VALUES(11, null, 1, null, 0, null, 0, '/', 1)" +
                "INSERT INTO Serita.MenuItemValues([Id], [IconName], [IsDefault], [ParentId], [HasSeparator], [ShortCut], [IsChecked], [Link], [Ordering]) VALUES(12, null, 1, null, 0, null, 0, '/', 2)" +

                "INSERT INTO Serita.MenuItemValues([Id], [IconName], [IsDefault], [ParentId], [HasSeparator], [ShortCut], [IsChecked], [Link], [Ordering]) VALUES(1010, null, 1, 10, 0, null, 0, '/', 0)" +
                "INSERT INTO Serita.MenuItemValues([Id], [IconName], [IsDefault], [ParentId], [HasSeparator], [ShortCut], [IsChecked], [Link], [Ordering]) VALUES(1011, null, 1, 10, 1, null, 0, '/', 1)" +
                "INSERT INTO Serita.MenuItemValues([Id], [IconName], [IsDefault], [ParentId], [HasSeparator], [ShortCut], [IsChecked], [Link], [Ordering]) VALUES(1012, null, 1, 10, 1, null, 0, '/', 2)" +
                "INSERT INTO Serita.MenuItemValues([Id], [IconName], [IsDefault], [ParentId], [HasSeparator], [ShortCut], [IsChecked], [Link], [Ordering]) VALUES(1013, null, 1, 10, 0, 'Alt+F4', 0, '/', 3)" +
                "INSERT INTO Serita.MenuItemValues([Id], [IconName], [IsDefault], [ParentId], [HasSeparator], [ShortCut], [IsChecked], [Link], [Ordering]) VALUES(1110, null, 1, 11, 0, 'Ctrl+Z', 0, '/', 0)" +
                "INSERT INTO Serita.MenuItemValues([Id], [IconName], [IsDefault], [ParentId], [HasSeparator], [ShortCut], [IsChecked], [Link], [Ordering]) VALUES(1111, null, 1, 11, 0, 'Ctrl+Y', 0, '/', 1)" +

                "INSERT INTO Serita.MenuItemValues([Id], [IconName], [IsDefault], [ParentId], [HasSeparator], [ShortCut], [IsChecked], [Link], [Ordering]) VALUES(101110, null, 1, 1011, 1, null, 0, '/', 0)";


            migrationBuilder.Sql(script);

            script = @"INSERT INTO Serita.MenuItemTitles([Id], [LanguageId], [Title]) VALUES(10, 1, N'File')" +
                "INSERT INTO Serita.MenuItemTitles([Id], [LanguageId], [Title]) VALUES(11, 1, N'Edit')" +
                "INSERT INTO Serita.MenuItemTitles([Id], [LanguageId], [Title]) VALUES(12, 1, N'View')" +

                "INSERT INTO Serita.MenuItemTitles([Id], [LanguageId], [Title]) VALUES(1010, 1, N'New')" +
                "INSERT INTO Serita.MenuItemTitles([Id], [LanguageId], [Title]) VALUES(1011, 1, N'Open')" +
                "INSERT INTO Serita.MenuItemTitles([Id], [LanguageId], [Title]) VALUES(1012, 1, N'Close')" +
                "INSERT INTO Serita.MenuItemTitles([Id], [LanguageId], [Title]) VALUES(1013, 1, N'Exit')" +
                "INSERT INTO Serita.MenuItemTitles([Id], [LanguageId], [Title]) VALUES(1110, 1, N'Undo')" +
                "INSERT INTO Serita.MenuItemTitles([Id], [LanguageId], [Title]) VALUES(1111, 1, N'Redo')" +

                "INSERT INTO Serita.MenuItemTitles([Id], [LanguageId], [Title]) VALUES(101110, 1, N'Project')";
            migrationBuilder.Sql(script);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string script = @"DELETE FROM Serita.MenuItemTitles";
            migrationBuilder.Sql(script);

            script = @"DELETE FROM Serita.MenuItemValues";
            migrationBuilder.Sql(script);
        }
    }
}
