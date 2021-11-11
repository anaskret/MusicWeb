using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class SongReviewTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "SongReview");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "SongReview",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "AlbumReview",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Review",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "SongReview");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "SongReview",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "AlbumReview",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "1",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Review");
        }
    }
}
