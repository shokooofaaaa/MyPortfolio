using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImagePathToProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF COL_LENGTH('tagharob_Myportfolio.Projects', 'ProfileImagePath') IS NOT NULL
   AND COL_LENGTH('tagharob_Myportfolio.Projects', 'ProjectImagePath') IS NULL
BEGIN
    EXEC sp_rename N'[tagharob_Myportfolio].[Projects].[ProfileImagePath]', N'ProjectImagePath', N'COLUMN';
END
ELSE IF COL_LENGTH('tagharob_Myportfolio.Projects', 'ProfileImagePath') IS NULL
    AND COL_LENGTH('tagharob_Myportfolio.Projects', 'ProjectImagePath') IS NULL
BEGIN
    ALTER TABLE [tagharob_Myportfolio].[Projects]
    ADD [ProjectImagePath] nvarchar(max) NULL;
END
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF COL_LENGTH('tagharob_Myportfolio.Projects', 'ProjectImagePath') IS NOT NULL
   AND COL_LENGTH('tagharob_Myportfolio.Projects', 'ProfileImagePath') IS NULL
BEGIN
    EXEC sp_rename N'[tagharob_Myportfolio].[Projects].[ProjectImagePath]', N'ProfileImagePath', N'COLUMN';
END
");
        }
    }
}
