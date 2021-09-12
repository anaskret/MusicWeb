using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class DeleteArtistGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistGenres");

            migrationBuilder.AddColumn<int>(
                name: "AlbumGenreId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_AlbumGenreId",
                table: "Albums",
                column: "AlbumGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Genres_AlbumGenreId",
                table: "Albums",
                column: "AlbumGenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Genres_AlbumGenreId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_AlbumGenreId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "AlbumGenreId",
                table: "Albums");

            migrationBuilder.CreateTable(
                name: "ArtistGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistGenres_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArtistGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistGenres_ArtistId",
                table: "ArtistGenres",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistGenres_GenreId",
                table: "ArtistGenres",
                column: "GenreId");
        }
    }
}
