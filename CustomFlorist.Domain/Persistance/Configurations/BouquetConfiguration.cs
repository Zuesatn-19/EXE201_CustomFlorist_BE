using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class BouquetConfiguration : IEntityTypeConfiguration<Bouquet>
{
    public void Configure(EntityTypeBuilder<Bouquet> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .IsRequired();
        builder.Property(b => b.Description)
            .IsRequired();
        builder.Property(b => b.BasePrice)
            .IsRequired();
        builder.Property(b => b.IsActive)
            .IsRequired();
        builder.Property(b => b.Category)
            .IsRequired();
        builder.Property(b => b.CategoryId)
            .IsRequired();
        builder.HasOne(b => b.Category)
            .WithMany(b => b.Bouquets)
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}