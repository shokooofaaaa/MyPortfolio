using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameAndAddNewPropertiesInProfileEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Profiles",
                newName: "ResumeFilePath");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Profiles",
                newName: "ProfileImagePath");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Profiles",
                newName: "JobTitleFa");

            migrationBuilder.RenameColumn(
                name: "About",
                table: "Profiles",
                newName: "JobTitleEn");

            migrationBuilder.AddColumn<string>(
                name: "FullNameEn",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullNameFa",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullNameEn",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "FullNameFa",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "ResumeFilePath",
                table: "Profiles",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ProfileImagePath",
                table: "Profiles",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "JobTitleFa",
                table: "Profiles",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "JobTitleEn",
                table: "Profiles",
                newName: "About");
        }
    }
}
