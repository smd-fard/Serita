using Microsoft.EntityFrameworkCore.Migrations;

namespace Shared.Data.Migrations
{
    public partial class Seed_Statuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string script = @"INSERT INTO Shared.StatusValues([Id], [IsDefault]) VALUES(0,1)" +
                "INSERT INTO Shared.StatusValues([Id], [IsDefault]) VALUES(1,1)";
            migrationBuilder.Sql(script);

            script = @"INSERT INTO Shared.StatusTitles([Id], [LanguageId], [Title]) VALUES(0,1,N'Inactive')" +
                "INSERT INTO Shared.StatusTitles([Id], [LanguageId], [Title]) VALUES(1,1,N'Active') " +
                "INSERT INTO Shared.StatusTitles([Id], [LanguageId], [Title]) VALUES(0,2,N'غیرفعال') " +
                "INSERT INTO Shared.StatusTitles([Id], [LanguageId], [Title]) VALUES(1,2,N'فعال')";
            migrationBuilder.Sql(script);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string script = @"DELETE FROM Shared.StatusTitles";
            migrationBuilder.Sql(script);

            script = @"DELETE FROM Shared.StatusValues";
            migrationBuilder.Sql(script);
        }
    }
}
