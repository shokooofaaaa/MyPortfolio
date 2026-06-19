using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPortfolio.Domain.Entities;

namespace MyPortfolio.Infrastructure.Mappings;

public class AboutMapping : IEntityTypeConfiguration<AboutEntity>
{
    public void Configure(EntityTypeBuilder<AboutEntity> builder)
    {
        builder.ToTable("About");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DescriptionEn)
            .IsRequired().HasColumnType("nvarchar(max)");

        builder.Property(x => x.DescriptionFa)
            .IsRequired().HasColumnType("nvarchar(max)");
    }
}
