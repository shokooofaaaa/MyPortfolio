using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReanameFieldOfWorkExprienceEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YearOfStart",
                table: "WorkExperiences",
                newName: "DateOfStart");

            migrationBuilder.RenameColumn(
                name: "YearOfEnd",
                table: "WorkExperiences",
                newName: "DateOfEnd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfStart",
                table: "WorkExperiences",
                newName: "YearOfStart");

            migrationBuilder.RenameColumn(
                name: "DateOfEnd",
                table: "WorkExperiences",
                newName: "YearOfEnd");
        }
    }
}
