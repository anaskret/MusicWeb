using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class PostFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_UserObservedArtist_ArtistPosterId",
                table: "Post");

            migrationBuilder.AddColumn<int>(
                name: "UserObservedArtistId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserObservedArtistId",
                table: "Post",
                column: "UserObservedArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Artist_ArtistPosterId",
                table: "Post",
                column: "ArtistPosterId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_UserObservedArtist_UserObservedArtistId",
                table: "Post",
                column: "UserObservedArtistId",
                principalTable: "UserObservedArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Artist_ArtistPosterId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_UserObservedArtist_UserObservedArtistId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_UserObservedArtistId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "UserObservedArtistId",
                table: "Post");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_UserObservedArtist_ArtistPosterId",
                table: "Post",
                column: "ArtistPosterId",
                principalTable: "UserObservedArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
