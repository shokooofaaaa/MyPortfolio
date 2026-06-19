using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EnglishAndPersionFieledsToEducationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Educations");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Educations",
                newName: "TitleFa");

            migrationBuilder.RenameColumn(
                name: "InstituteName",
                table: "Educations",
                newName: "TitleEn");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionFa",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstituteNameEn",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstituteNameFa",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "DescriptionFa",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "InstituteNameEn",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "InstituteNameFa",
                table: "Educations");

            migrationBuilder.RenameColumn(
                name: "TitleFa",
                table: "Educations",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TitleEn",
                table: "Educations",
                newName: "InstituteName");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Educations",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
