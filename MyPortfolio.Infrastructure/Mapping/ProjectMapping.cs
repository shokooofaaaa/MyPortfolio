using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPortfolio.Domain.Entities;

namespace MyPortfolio.Infrastructure.Mappings;

public class ProjectMapping : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.ToTable("Projects");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TitleFa)
            .HasMaxLength(200);

        builder.Property(x => x.TitleEn)
            .HasMaxLength(200);

        builder.Property(x => x.GithubUrl)
            .HasMaxLength(500);

        builder.Property(x => x.ProjectImagePath)
            .HasMaxLength(500);

        builder.Property(x => x.DescriptionFa)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.DescriptionEn)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.IsDelete)
            .IsRequired();
    }
}

