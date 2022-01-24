using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class AddIdToTopSongs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TopSongsWithRating",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "TopSongsWithRating");
        }
    }
}
