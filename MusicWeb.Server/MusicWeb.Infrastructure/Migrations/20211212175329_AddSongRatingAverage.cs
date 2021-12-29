using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class AddSongRatingAverage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "SongRatingAverage",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                Length = table.Column<double>(type: "float", nullable: false),
                ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                PositionOnAlbum = table.Column<int>(type:"int", nullable: false),
                Text  = table.Column<string>(type: "nvarchar(max)", nullable: false),
                AlbumId = table.Column<int>(type: "int", nullable: false),
                ComposerId = table.Column<int>(type: "int", nullable: false),
                Rating = table.Column<double>(type: "float", nullable: false), 
                RatingsCount = table.Column<int>(type:"int", nullable: false)
            },
            constraints: table =>
            {
            });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "SongRatingAverage");
        }
    }
}
