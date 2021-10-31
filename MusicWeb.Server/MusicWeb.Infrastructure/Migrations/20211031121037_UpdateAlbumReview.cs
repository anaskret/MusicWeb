using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class UpdateAlbumReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AlbumReview",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AlbumReview");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "AlbumReview",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }
    }
}
