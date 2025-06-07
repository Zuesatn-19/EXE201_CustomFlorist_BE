using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class BouquetCompositionConfiguration : IEntityTypeConfiguration<BouquetComposition>
{
    public void Configure(EntityTypeBuilder<BouquetComposition> builder)
    {
        builder.HasKey(bc => bc.Id);

        builder.Property(bc => bc.MinQuantity)
            .IsRequired(false);
        builder.Property(bc => bc.MaxQuantity)
            .IsRequired(false);
        builder.Property(bc => bc.Quantity)
            .IsRequired();
        builder.Property(bc => bc.IsActive)
            .IsRequired();

        builder.HasOne(bc => bc.Bouquet)
            .WithMany(b => b.BouquetCompositions)
            .HasForeignKey(bc => bc.BouquetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bc => bc.Flower)
            .WithMany(f => f.BouquetCompositions)
            .HasForeignKey(bc => bc.FlowerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}