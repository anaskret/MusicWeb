using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class UpdateArtistRatingAverage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Popularity",
                table: "ArtistRatingAverage",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteCount",
                table: "ArtistRatingAverage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RatingsCount",
                table: "ArtistRatingAverage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteCount",
                table: "ArtistRatingAverage");

            migrationBuilder.DropColumn(
                name: "RatingsCount",
                table: "ArtistRatingAverage");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "ArtistRatingAverage",
                newName: "Popularity");
        }
    }
}
