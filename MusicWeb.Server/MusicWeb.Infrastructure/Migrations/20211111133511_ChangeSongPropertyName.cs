using Microsoft.EntityFrameworkCore.Migrations;

using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class ChangeSongPropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "text",
                table: "Song",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "positionOnAlbum",
                table: "Song",
                newName: "PositionOnAlbum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Song",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "PositionOnAlbum",
                table: "Song",
                newName: "positionOnAlbum");
        }
    }
}
