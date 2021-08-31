using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicWeb.DataAccess.Migrations
{
    public partial class OriginsAndBandMemberUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Origins_OriginId",
                table: "Artists");

            migrationBuilder.DropTable(
                name: "Origins");

            migrationBuilder.DropIndex(
                name: "IX_BandMembers_ArtistId",
                table: "BandMembers");

            migrationBuilder.RenameColumn(
                name: "OriginId",
                table: "Artists",
                newName: "StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_OriginId",
                table: "Artists",
                newName: "IX_Artists_StateId");

            migrationBuilder.AddColumn<int>(
                name: "BandId",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBand",
                table: "Artists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BandMembers_ArtistId",
                table: "BandMembers",
                column: "ArtistId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_CityId",
                table: "Artists",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_CountryId",
                table: "Artists",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Cities_CityId",
                table: "Artists",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Countries_CountryId",
                table: "Artists",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_States_StateId",
                table: "Artists",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Cities_CityId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Countries_CountryId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_States_StateId",
                table: "Artists");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_BandMembers_ArtistId",
                table: "BandMembers");

            migrationBuilder.DropIndex(
                name: "IX_Artists_CityId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_CountryId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "BandId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "IsBand",
                table: "Artists");

            migrationBuilder.RenameColumn(
                name: "StateId",
                table: "Artists",
                newName: "OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_Artists_StateId",
                table: "Artists",
                newName: "IX_Artists_OriginId");

            migrationBuilder.CreateTable(
                name: "Origins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BandMembers_ArtistId",
                table: "BandMembers",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Origins_OriginId",
                table: "Artists",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
