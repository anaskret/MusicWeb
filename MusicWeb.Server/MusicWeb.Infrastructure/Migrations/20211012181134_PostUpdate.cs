using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class PostUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Album_AlbumId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_UserFriend_PosterId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_AlbumId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_PosterId",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "PosterId",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PosterId1",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_PosterId1",
                table: "Post",
                column: "PosterId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_UserFriend_PosterId1",
                table: "Post",
                column: "PosterId1",
                principalTable: "UserFriend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_UserFriend_PosterId1",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_PosterId1",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PosterId1",
                table: "Post");

            migrationBuilder.AlterColumn<int>(
                name: "PosterId",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_AlbumId",
                table: "Post",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_PosterId",
                table: "Post",
                column: "PosterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Album_AlbumId",
                table: "Post",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_UserFriend_PosterId",
                table: "Post",
                column: "PosterId",
                principalTable: "UserFriend",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
