using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FictionalProgrammers.DataAccess.Migrations
{
    public partial class addUpdateToProgrammer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Programmers",
                table: "Programmers");

            migrationBuilder.RenameTable(
                name: "Programmers",
                newName: "Programmer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programmer",
                table: "Programmer",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Programmer",
                table: "Programmer");

            migrationBuilder.RenameTable(
                name: "Programmer",
                newName: "Programmers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programmers",
                table: "Programmers",
                column: "Id");
        }
    }
}
