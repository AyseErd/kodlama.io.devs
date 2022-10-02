using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddLanguageFramework_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LanguageFrameworks",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId", "Version" },
                values: new object[] { 1, "JSP", 3, "3.1" });

            migrationBuilder.InsertData(
                table: "LanguageFrameworks",
                columns: new[] { "Id", "Name", "ProgrammingLanguageId", "Version" },
                values: new object[] { 2, "ASP.NET", 4, "4.7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguageFrameworks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LanguageFrameworks",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
