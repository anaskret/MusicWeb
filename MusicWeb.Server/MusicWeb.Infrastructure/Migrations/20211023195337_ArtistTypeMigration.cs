using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class ArtistTypeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBand",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "IsIndividual",
                table: "Artist");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Artist",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Artist");

            migrationBuilder.AddColumn<bool>(
                name: "IsBand",
                table: "Artist",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsIndividual",
                table: "Artist",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
