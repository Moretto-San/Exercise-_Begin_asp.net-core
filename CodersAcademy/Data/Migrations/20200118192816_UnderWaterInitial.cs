using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodersAcademy.Data.Migrations
{
    public partial class UnderWaterInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aquarium",
                columns: table => new
                {
                    AquariumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    Number = table.Column<string>(maxLength: 200, nullable: false),
                    Open = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aquarium", x => x.AquariumId);
                });

            migrationBuilder.CreateTable(
                name: "Fish",
                columns: table => new
                {
                    FishId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    ScientificName = table.Column<string>(maxLength: 300, nullable: false),
                    CommonName = table.Column<string>(maxLength: 300, nullable: true),
                    PhotoAvatar = table.Column<byte[]>(nullable: true),
                    ImageName = table.Column<string>(maxLength: 300, nullable: false),
                    PhotoFile = table.Column<byte[]>(maxLength: 300, nullable: true),
                    ImageMimeType = table.Column<string>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    AquariumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fish", x => x.FishId);
                    table.ForeignKey(
                        name: "FK_Fish_Aquarium_AquariumId",
                        column: x => x.AquariumId,
                        principalTable: "Aquarium",
                        principalColumn: "AquariumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fish_AquariumId",
                table: "Fish",
                column: "AquariumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fish");

            migrationBuilder.DropTable(
                name: "Aquarium");
        }
    }
}
