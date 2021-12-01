using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class RemoveReviewCharacterLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Content",
            table: "AlbumReview",
            maxLength: null);

            migrationBuilder.AlterColumn<string>(
            name: "Content",
            table: "SongReview",
            maxLength: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "ArtistRatingAverage",
                newName: "CityId");
        }
    }
}
