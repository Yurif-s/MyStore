using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStore.Domain.Entities;

namespace MyStore.Infrastructure.Data.Configurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Url)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(i => i.IsPrimary)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(i => i.DisplayOrder)
            .IsRequired()
            .HasDefaultValue(0);

        builder.HasIndex(i => new { i.ProductId, i.IsPrimary })
            .IsUnique()
            .HasFilter("[IsPrimary] = 1");
    }
}
