using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EnglishAndPersionFieldsToWOrkExperience : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "WorkExperiences",
                newName: "TitleFa");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "WorkExperiences",
                newName: "TitleEn");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "WorkExperiences",
                newName: "DescriptionFa");

            migrationBuilder.AddColumn<string>(
                name: "CompanyNameEn",
                table: "WorkExperiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyNameFa",
                table: "WorkExperiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "WorkExperiences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyNameEn",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "CompanyNameFa",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "WorkExperiences");

            migrationBuilder.RenameColumn(
                name: "TitleFa",
                table: "WorkExperiences",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TitleEn",
                table: "WorkExperiences",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "DescriptionFa",
                table: "WorkExperiences",
                newName: "CompanyName");
        }
    }
}
