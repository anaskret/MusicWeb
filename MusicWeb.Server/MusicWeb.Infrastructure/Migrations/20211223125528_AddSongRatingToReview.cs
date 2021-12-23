using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class AddSongRatingToReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "SongReview",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SongReview_RatingId",
                table: "SongReview",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_SongReview_SongRating_RatingId",
                table: "SongReview",
                column: "RatingId",
                principalTable: "SongRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongReview_SongRating_RatingId",
                table: "SongReview");

            migrationBuilder.DropIndex(
                name: "IX_SongReview_RatingId",
                table: "SongReview");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "SongReview");
        }
    }
}
