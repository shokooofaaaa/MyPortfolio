using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NullableDateTimeANDAddDescriptionToEducationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FieldOfStudy",
                table: "Educations",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "Educations",
                newName: "Description");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEnd",
                table: "Educations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Educations",
                newName: "FieldOfStudy");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Educations",
                newName: "Degree");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfEnd",
                table: "Educations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
