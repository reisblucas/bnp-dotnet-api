using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend_challenge.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SuperPowers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPowers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UniformColors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniformColors", x => x.id);
                    table.ForeignKey(
                        name: "FK_UniformColors_Heroes_id",
                        column: x => x.id,
                        principalTable: "Heroes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroSuperpowers",
                columns: table => new
                {
                    Heroesid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Superpowersid = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSuperpowers", x => new { x.Heroesid, x.Superpowersid });
                    table.ForeignKey(
                        name: "FK_HeroSuperpowers_Heroes_Heroesid",
                        column: x => x.Heroesid,
                        principalTable: "Heroes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroSuperpowers_SuperPowers_Superpowersid",
                        column: x => x.Superpowersid,
                        principalTable: "SuperPowers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SuperPowers",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("37e65689-3a35-4634-8496-2f7acdee0d30"), "Healing" },
                    { new Guid("5813bdb2-cfc7-4a34-8785-baf28ee5dda4"), "Teleportation" },
                    { new Guid("66786146-6e06-43dd-a4f4-e6977d7d9649"), "Super Speed" },
                    { new Guid("81ca26ce-ae53-4c99-b1c6-2acfe9ba6ad4"), "Flight" },
                    { new Guid("d1e1f4ce-6e44-4628-804a-49b0ae4a0cab"), "Super Strength" },
                    { new Guid("e9a950dc-e5e6-4785-92e8-b6956ed0ceea"), "Mind Control" },
                    { new Guid("ed2245c5-c512-4502-8ea9-f882c40de755"), "Telekinesis" },
                    { new Guid("f7760e9f-b5e6-4d28-b7fe-444612ed4e32"), "Invisibility" }
                });

            migrationBuilder.InsertData(
                table: "UniformColors",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("02688205-3e7f-4db4-9c0e-1bd7292c185e"), "Purple" },
                    { new Guid("2fed141a-955a-4f9a-ad6c-4a11d7e1164d"), "Black" },
                    { new Guid("76445352-1fb3-4e13-9f2d-7603923eb455"), "Green" },
                    { new Guid("8e94e220-1f1a-4ca0-bfcf-5ede21b91a8d"), "Red" },
                    { new Guid("ad0ffdf5-05cb-40dd-bc76-8748b5013bec"), "Orange" },
                    { new Guid("b228db8d-eaa4-4b2b-beb8-ee85469d5dac"), "Blue" },
                    { new Guid("d98c10d3-4de1-41c8-8cb1-b537127e5dea"), "White" },
                    { new Guid("e22c9702-7652-47be-ba98-8ca34de974e2"), "Yellow" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroSuperpowers_Superpowersid",
                table: "HeroSuperpowers",
                column: "Superpowersid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroSuperpowers");

            migrationBuilder.DropTable(
                name: "UniformColors");

            migrationBuilder.DropTable(
                name: "SuperPowers");

            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
