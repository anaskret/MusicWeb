using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class AddRatingToAlbumReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlbumReview_RatingId",
                table: "AlbumReview");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "AlbumRating",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumReview_RatingId",
                table: "AlbumReview",
                column: "RatingId",
                unique: true,
                filter: "[RatingId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AlbumReview_RatingId",
                table: "AlbumReview");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "AlbumRating");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumReview_RatingId",
                table: "AlbumReview",
                column: "RatingId");
        }
    }
}
