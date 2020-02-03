using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmstudion.Migrations
{
    public partial class somechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmStudios",
                table: "FilmStudios");

            migrationBuilder.DropColumn(
                name: "StudioName",
                table: "FilmStudios");

            migrationBuilder.RenameTable(
                name: "FilmStudios",
                newName: "Filmstudios");

            migrationBuilder.RenameColumn(
                name: "FilmStudioId",
                table: "Filmstudios",
                newName: "FilmstudioId");

            migrationBuilder.AddColumn<string>(
                name: "FilmstudioName",
                table: "Filmstudios",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filmstudios",
                table: "Filmstudios",
                column: "FilmstudioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Filmstudios",
                table: "Filmstudios");

            migrationBuilder.DropColumn(
                name: "FilmstudioName",
                table: "Filmstudios");

            migrationBuilder.RenameTable(
                name: "Filmstudios",
                newName: "FilmStudios");

            migrationBuilder.RenameColumn(
                name: "FilmstudioId",
                table: "FilmStudios",
                newName: "FilmStudioId");

            migrationBuilder.AddColumn<string>(
                name: "StudioName",
                table: "FilmStudios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmStudios",
                table: "FilmStudios",
                column: "FilmStudioId");
        }
    }
}
