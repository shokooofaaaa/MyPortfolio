using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPortfolio.Domain.Entities;

namespace MyPortfolio.Infrastructure.Mappings;

public class WorkExperienceMapping : IEntityTypeConfiguration<WorkExperienceEntity>
{
    public void Configure(EntityTypeBuilder<WorkExperienceEntity> builder)
    {
        builder.ToTable("WorkExperiences");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TitleFa)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.TitleEn)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.CompanyNameFa)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.CompanyNameEn)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.DescriptionFa)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.DescriptionEn)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.DateOfStart)
            .IsRequired();

        builder.Property(x => x.DateOfEnd);

        builder.Property(x => x.IsDelete)
            .IsRequired();
    }
}
