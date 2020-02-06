using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmstudion.Migrations
{
    public partial class ratingchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ratings_FilmstudioId",
                table: "Ratings",
                column: "FilmstudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Filmstudios_FilmstudioId",
                table: "Ratings",
                column: "FilmstudioId",
                principalTable: "Filmstudios",
                principalColumn: "FilmstudioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Filmstudios_FilmstudioId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_FilmstudioId",
                table: "Ratings");
        }
    }
}
