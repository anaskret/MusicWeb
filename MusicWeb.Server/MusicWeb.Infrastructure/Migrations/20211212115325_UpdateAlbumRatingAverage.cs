using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class UpdateAlbumRatingAverage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "duration",
                table: "AlbumRatingAverage",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "AlbumRatingAverage",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Popularity",
                table: "AlbumRatingAverage",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "RatingsCount",
                table: "AlbumRatingAverage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingsCount",
                table: "AlbumRatingAverage");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "AlbumRatingAverage",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "AlbumRatingAverage",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "AlbumRatingAverage",
                newName: "Popularity");
        }
    }
}
