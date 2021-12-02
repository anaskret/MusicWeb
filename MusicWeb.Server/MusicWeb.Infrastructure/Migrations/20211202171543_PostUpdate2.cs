using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class PostUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_UserObservedArtist_UserObservedArtistId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "UserObservedArtistId",
                table: "Post",
                newName: "PosterArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_UserObservedArtistId",
                table: "Post",
                newName: "IX_Post_PosterArtistId");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "ArtistRatingAverage",
                newName: "CountryId");

            migrationBuilder.AddColumn<int>(
                name: "AlbumId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtistPosterId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserAndArtistPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistId = table.Column<int>(type: "int", nullable: true),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlbumId = table.Column<int>(type: "int", nullable: true),
                    Album = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_AlbumId",
                table: "Post",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Album_AlbumId",
                table: "Post",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_UserObservedArtist_PosterArtistId",
                table: "Post",
                column: "PosterArtistId",
                principalTable: "UserObservedArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Album_AlbumId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_UserObservedArtist_PosterArtistId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "UserAndArtistPost");

            migrationBuilder.DropIndex(
                name: "IX_Post_AlbumId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ArtistPosterId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "PosterArtistId",
                table: "Post",
                newName: "UserObservedArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_PosterArtistId",
                table: "Post",
                newName: "IX_Post_UserObservedArtistId");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "ArtistRatingAverage",
                newName: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_UserObservedArtist_UserObservedArtistId",
                table: "Post",
                column: "UserObservedArtistId",
                principalTable: "UserObservedArtist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
