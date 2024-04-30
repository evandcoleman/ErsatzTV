﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErsatzTV.Infrastructure.MySql.Migrations
{
    /// <inheritdoc />
    public partial class Add_Playlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaylistGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistGroup", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlaylistGroupId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlist_PlaylistGroup_PlaylistGroupId",
                        column: x => x.PlaylistGroupId,
                        principalTable: "PlaylistGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlaylistItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Index = table.Column<int>(type: "int", nullable: false),
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    CollectionType = table.Column<int>(type: "int", nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: true),
                    MediaItemId = table.Column<int>(type: "int", nullable: true),
                    MultiCollectionId = table.Column<int>(type: "int", nullable: true),
                    SmartCollectionId = table.Column<int>(type: "int", nullable: true),
                    PlaybackOrder = table.Column<int>(type: "int", nullable: false),
                    IncludeInProgramGuide = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistItem_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistItem_MediaItem_MediaItemId",
                        column: x => x.MediaItemId,
                        principalTable: "MediaItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistItem_MultiCollection_MultiCollectionId",
                        column: x => x.MultiCollectionId,
                        principalTable: "MultiCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistItem_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistItem_SmartCollection_SmartCollectionId",
                        column: x => x.SmartCollectionId,
                        principalTable: "SmartCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_PlaylistGroupId_Name",
                table: "Playlist",
                columns: new[] { "PlaylistGroupId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistGroup_Name",
                table: "PlaylistGroup",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistItem_CollectionId",
                table: "PlaylistItem",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistItem_MediaItemId",
                table: "PlaylistItem",
                column: "MediaItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistItem_MultiCollectionId",
                table: "PlaylistItem",
                column: "MultiCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistItem_PlaylistId",
                table: "PlaylistItem",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistItem_SmartCollectionId",
                table: "PlaylistItem",
                column: "SmartCollectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistItem");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "PlaylistGroup");
        }
    }
}
