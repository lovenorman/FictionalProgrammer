using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FictionalProgrammers.DataAccess.Migrations
{
    public partial class addProgrammer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Programs",
                table: "Programs");

            migrationBuilder.RenameTable(
                name: "Programs",
                newName: "Programmers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programmers",
                table: "Programmers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Programmers",
                table: "Programmers");

            migrationBuilder.RenameTable(
                name: "Programmers",
                newName: "Programs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Programs",
                table: "Programs",
                column: "Id");
        }
    }
}
