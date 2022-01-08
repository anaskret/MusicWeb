using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class AddWatchedAndReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.AddColumn<int>(
                name: "ReviewsCount",
                table: "SongRatingAverage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReviewsCount",
                table: "ArtistRatingAverage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ObservedCount",
                table: "AlbumRatingAverage",
                type: "int",
                nullable: false,
                defaultValue: 0);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "ReviewsCount",
                table: "SongRatingAverage");

            migrationBuilder.DropColumn(
                name: "ReviewsCount",
                table: "ArtistRatingAverage");

            migrationBuilder.DropColumn(
                name: "ObservedCount",
                table: "AlbumRatingAverage");

        }
    }
}
