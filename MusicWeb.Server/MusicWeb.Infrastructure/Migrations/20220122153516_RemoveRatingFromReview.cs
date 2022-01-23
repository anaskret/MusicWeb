using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class RemoveRatingFromReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumRating_AlbumReview_ReviewId",
                table: "AlbumRating");

            migrationBuilder.DropIndex(
                name: "IX_AlbumRating_ReviewId",
                table: "AlbumRating");


            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "AlbumRating");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
