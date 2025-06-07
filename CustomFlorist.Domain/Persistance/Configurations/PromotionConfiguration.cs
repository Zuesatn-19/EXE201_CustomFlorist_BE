using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
    public void Configure(EntityTypeBuilder<Promotion> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.PromotionCode)
            .IsRequired()
            .HasMaxLength(255);
        builder.HasIndex(p => p.PromotionCode)
            .IsUnique();

        builder.Property(p => p.DiscountPercentage)
            .IsRequired();

        builder.Property(p => p.ValidFrom)
            .IsRequired();
        builder.Property(p => p.ValidTo)
            .IsRequired();
        builder.Property(p => p.IsActive)
            .IsRequired();
    }
}