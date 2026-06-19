using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeutschDescriptionToProfileEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobTitleEn",
                table: "Profiles",
                newName: "JobTitleDE");

            migrationBuilder.RenameColumn(
                name: "FullNameEn",
                table: "Profiles",
                newName: "FullNameDE");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionDE",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionDE",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "JobTitleDE",
                table: "Profiles",
                newName: "JobTitleEn");

            migrationBuilder.RenameColumn(
                name: "FullNameDE",
                table: "Profiles",
                newName: "FullNameEn");
        }
    }
}
