using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmstudion.Migrations
{
    public partial class movieentitychanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<bool>(
                name: "AvailableForLending",
                table: "Movies",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableForLending",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "Lending",
                columns: table => new
                {
                    FilmstudioId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lending", x => new { x.FilmstudioId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_Lending_Filmstudios_FilmstudioId",
                        column: x => x.FilmstudioId,
                        principalTable: "Filmstudios",
                        principalColumn: "FilmstudioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lending_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lending_MovieId",
                table: "Lending",
                column: "MovieId");
        }
    }
}
