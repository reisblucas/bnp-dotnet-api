using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend_challenge.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    Heroid = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPowers", x => x.id);
                    table.ForeignKey(
                        name: "FK_SuperPowers_Heroes_Heroid",
                        column: x => x.Heroid,
                        principalTable: "Heroes",
                        principalColumn: "id");
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
                    HeroId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SuperpowerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSuperpowers", x => new { x.HeroId, x.SuperpowerId });
                    table.ForeignKey(
                        name: "FK_HeroSuperpowers_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroSuperpowers_SuperPowers_SuperpowerId",
                        column: x => x.SuperpowerId,
                        principalTable: "SuperPowers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SuperPowers",
                columns: new[] { "id", "Heroid", "name" },
                values: new object[,]
                {
                    { new Guid("09702387-0f1c-4b11-af45-f93aab2c0ed3"), null, "Super Speed" },
                    { new Guid("444072c0-3f51-494c-bf72-979e35a88fb9"), null, "Flight" },
                    { new Guid("83864131-d564-4e7f-9250-8bb2d1d96f20"), null, "Teleportation" },
                    { new Guid("89b75b4c-1c0f-4fa1-83fd-9602339cb0dd"), null, "Mind Control" },
                    { new Guid("9fb6500b-c7fc-4681-8574-197330792c46"), null, "Super Strength" },
                    { new Guid("cef07ac2-3f3b-4ba2-adfd-d603f5db1ca6"), null, "Healing" },
                    { new Guid("e6c13a5c-9625-48d0-9bd9-c91435f3361e"), null, "Invisibility" },
                    { new Guid("ea5c545c-bca6-41fd-8b82-7875a1b7b1c3"), null, "Telekinesis" }
                });

            migrationBuilder.InsertData(
                table: "UniformColors",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("1c628125-6eb0-42f8-872a-59cac063775e"), "Red" },
                    { new Guid("3588576e-36e2-4c60-9027-40e843592526"), "Yellow" },
                    { new Guid("3a490cf4-c716-4abe-8b0d-2d74751a99e8"), "Green" },
                    { new Guid("4e767aa0-81f5-45a9-aaf6-11a9d9fea1e3"), "Blue" },
                    { new Guid("ac5607a2-3ece-42bc-9460-727310e1c133"), "Orange" },
                    { new Guid("c14713bb-777d-472a-9d5d-6113ad78ef2c"), "Black" },
                    { new Guid("d703951f-117b-4357-89ba-8deeee852eee"), "Purple" },
                    { new Guid("dab280fa-7437-4685-b0b5-b6beee271a74"), "White" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroSuperpowers_SuperpowerId",
                table: "HeroSuperpowers",
                column: "SuperpowerId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowers_Heroid",
                table: "SuperPowers",
                column: "Heroid");
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
