using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPortfolio.Domain.Entities;

namespace MyPortfolio.Infrastructure.Mappings;

public class EducationMapping : IEntityTypeConfiguration<EducationEntity>
{
    public void Configure(EntityTypeBuilder<EducationEntity> builder)
    {
        builder.ToTable("Educations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TitleFa)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.TitleEn)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.InstituteNameFa)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.InstituteNameEn)
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
