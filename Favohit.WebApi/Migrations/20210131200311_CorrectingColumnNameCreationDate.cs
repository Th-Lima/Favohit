using Microsoft.EntityFrameworkCore.Migrations;

namespace Favohit.WebApi.Migrations
{
    public partial class CorrectingColumnNameCreationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationData",
                table: "User",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreationData",
                table: "Music",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "CreationData",
                table: "Album",
                newName: "CreationDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "User",
                newName: "CreationData");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Music",
                newName: "CreationData");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Album",
                newName: "CreationData");
        }
    }
}
