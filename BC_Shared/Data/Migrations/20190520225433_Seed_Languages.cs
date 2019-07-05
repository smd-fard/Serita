using Microsoft.EntityFrameworkCore.Migrations;

namespace Shared.Data.Migrations
{
    public partial class Seed_Languages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string script = @"INSERT INTO Shared.Languages([Id],[IsDefault], [Title], [Code]) VALUES(1, 1, N'English', 'EN') " +
                "INSERT INTO Shared.Languages([Id],[IsDefault], [Title], [Code]) VALUES(2, 1, N'فارسی', 'FA') ";
            migrationBuilder.Sql(script);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string script = @"DELETE FROM Shared.Languages";
            migrationBuilder.Sql(script);
        }
    }
}
