using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class AddRatingToAlbumReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "AlbumReview",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlbumReview_RatingId",
                table: "AlbumReview",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumReview_AlbumRating_RatingId",
                table: "AlbumReview",
                column: "RatingId",
                principalTable: "AlbumRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumReview_AlbumRating_RatingId",
                table: "AlbumReview");

            migrationBuilder.DropIndex(
                name: "IX_AlbumReview_RatingId",
                table: "AlbumReview");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "AlbumReview");
        }
    }
}
