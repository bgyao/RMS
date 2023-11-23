using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMS.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDevotionsBibleBooksTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AppDevotions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppBibleBooks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppBibleBooks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppBibleBooks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppBibleBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppBibleBooks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppBibleBooks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppBibleBooks",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "AppDevotions");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppBibleBooks");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppBibleBooks");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppBibleBooks");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppBibleBooks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppBibleBooks");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppBibleBooks");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppBibleBooks");
        }
    }
}
