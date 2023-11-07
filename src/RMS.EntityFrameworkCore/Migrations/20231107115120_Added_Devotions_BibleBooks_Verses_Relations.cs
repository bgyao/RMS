using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMS.Migrations
{
    /// <inheritdoc />
    public partial class AddedDevotionsBibleBooksVersesRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppDevotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDevotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppBibleBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DevotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookName = table.Column<int>(type: "int", nullable: false),
                    Chapter = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppBibleBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppBibleBooks_AppDevotions_DevotionId",
                        column: x => x.DevotionId,
                        principalTable: "AppDevotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppVerses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BibleBookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VerseNumber = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVerses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppVerses_AppBibleBooks_BibleBookId",
                        column: x => x.BibleBookId,
                        principalTable: "AppBibleBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppBibleBooks_DevotionId",
                table: "AppBibleBooks",
                column: "DevotionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppVerses_BibleBookId",
                table: "AppVerses",
                column: "BibleBookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppVerses");

            migrationBuilder.DropTable(
                name: "AppBibleBooks");

            migrationBuilder.DropTable(
                name: "AppDevotions");
        }
    }
}
