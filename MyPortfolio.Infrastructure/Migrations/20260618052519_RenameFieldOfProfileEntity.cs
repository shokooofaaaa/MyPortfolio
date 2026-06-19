using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameFieldOfProfileEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobTitleDE",
                table: "Profiles",
                newName: "JobTitleEn");

            migrationBuilder.RenameColumn(
                name: "FullNameDE",
                table: "Profiles",
                newName: "FullNameEn");

            migrationBuilder.RenameColumn(
                name: "DescriptionDE",
                table: "Profiles",
                newName: "DescriptionFa");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Profiles",
                newName: "DescriptionEn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobTitleEn",
                table: "Profiles",
                newName: "JobTitleDE");

            migrationBuilder.RenameColumn(
                name: "FullNameEn",
                table: "Profiles",
                newName: "FullNameDE");

            migrationBuilder.RenameColumn(
                name: "DescriptionFa",
                table: "Profiles",
                newName: "DescriptionDE");

            migrationBuilder.RenameColumn(
                name: "DescriptionEn",
                table: "Profiles",
                newName: "Description");
        }
    }
}
