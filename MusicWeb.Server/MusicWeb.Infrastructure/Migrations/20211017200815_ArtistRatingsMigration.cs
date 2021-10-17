using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class ArtistRatingsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_UserFriend_PosterId1",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_UserObservedArtist_PosterArtistId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_UserFriend_FriendId",
                table: "UserFriend");

            migrationBuilder.DropIndex(
                name: "IX_Post_PosterArtistId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ArtistPosterId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PosterArtistId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "PosterId1",
                table: "Post",
                newName: "UserObservedArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_PosterId1",
                table: "Post",
                newName: "IX_Post_UserObservedArtistId");

            migrationBuilder.AlterColumn<string>(
                name: "PosterId",
                table: "Post",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_UserFriend_FriendId",
                table: "UserFriend",
                column: "FriendId");

            migrationBuilder.CreateTable(
                name: "ArtistRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistRating_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtistRating_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_PosterId",
                table: "Post",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistRating_ArtistId",
                table: "ArtistRating",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistRating_UserId",
                table: "ArtistRating",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_UserFriend_PosterId",
                table: "Post",
                column: "PosterId",
                principalTable: "UserFriend",
                principalColumn: "FriendId",
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
                name: "FK_Post_UserFriend_PosterId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_UserObservedArtist_UserObservedArtistId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "ArtistRating");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_UserFriend_FriendId",
                table: "UserFriend");

            migrationBuilder.DropIndex(
                name: "IX_Post_PosterId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "UserObservedArtistId",
                table: "Post",
                newName: "PosterId1");

            migrationBuilder.RenameIndex(
                name: "IX_Post_UserObservedArtistId",
                table: "Post",
                newName: "IX_Post_PosterId1");

            migrationBuilder.AlterColumn<string>(
                name: "PosterId",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "PosterArtistId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFriend_FriendId",
                table: "UserFriend",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_PosterArtistId",
                table: "Post",
                column: "PosterArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_UserFriend_PosterId1",
                table: "Post",
                column: "PosterId1",
                principalTable: "UserFriend",
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
    }
}
