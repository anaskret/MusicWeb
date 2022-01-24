using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class UpdateAlbumReviewandSongReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Album",
                table: "SongReviewRating",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "SongReviewRating",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SongReviewRating",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "AlbumReviewRating",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AlbumReviewRating",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Album",
                table: "SongReviewRating");

            migrationBuilder.DropColumn(
                name: "Artist",
                table: "SongReviewRating");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SongReviewRating");

            migrationBuilder.DropColumn(
                name: "Artist",
                table: "AlbumReviewRating");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AlbumReviewRating");
        }
    }
}
