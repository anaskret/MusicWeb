using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class AddWatchedAndReviewsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReviewsCount",
                table: "ArtistRatingAverage",
                newName: "ObservedCount");

            migrationBuilder.RenameColumn(
                name: "ObservedCount",
                table: "AlbumRatingAverage",
                newName: "ReviewsCount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ObservedCount",
                table: "ArtistRatingAverage",
                newName: "ReviewsCount");

            migrationBuilder.RenameColumn(
                name: "ReviewsCount",
                table: "AlbumRatingAverage",
                newName: "ObservedCount");
        }
    }
}
