using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmstudion.Migrations
{
    public partial class changedfilmstudiomodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Filmstudios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Filmstudios");
        }
    }
}
