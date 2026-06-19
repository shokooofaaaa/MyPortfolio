using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPortfolio.Domain.Entities;

namespace MyPortfolio.Infrastructure.Mappings;

public class ProfileMapping : IEntityTypeConfiguration<ProfileEntity>
{
    public void Configure(EntityTypeBuilder<ProfileEntity> builder)
    {
        builder.ToTable("Profiles");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FullNameFa)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.FullNameEn)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.JobTitleFa)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.JobTitleEn)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.ProfileImagePath)
            .HasMaxLength(500);

        builder.Property(x => x.DescriptionFa)
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.DescriptionEn)
            .HasColumnType("nvarchar(max)");
    }
}
