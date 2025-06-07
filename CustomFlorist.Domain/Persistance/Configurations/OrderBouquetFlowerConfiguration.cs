using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class OrderBouquetFlowerConfiguration : IEntityTypeConfiguration<OrderBouquetFlower>
{
    public void Configure(EntityTypeBuilder<OrderBouquetFlower> builder)
    {
        builder.HasKey(obf => obf.Id);
        builder.Property(obf => obf.Quantity)
            .IsRequired();
        builder.HasOne(obf => obf.OrderItem)
            .WithMany(oi => oi.OrderBouquetFlowers)
            .HasForeignKey(obf => obf.OrderItemId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(obf => obf.Flower)
            .WithMany(f => f.OrderBouquetFlowers)
            .HasForeignKey(obf => obf.FlowerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}