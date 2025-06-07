using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class FlowerConfiguration : IEntityTypeConfiguration<Flower>
{
    public void Configure(EntityTypeBuilder<Flower> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Name)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(f => f.FlowerType)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(f => f.Color)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(f => f.Price);
        builder.Property(f => f.Image)
            .HasMaxLength(255)
            .IsRequired();
        builder.Property(f => f.IsActive)
            .IsRequired();
    }
}