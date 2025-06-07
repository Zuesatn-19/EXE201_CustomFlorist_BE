using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);
        
        builder.Property(oi => oi.Quantity)
            .IsRequired();
        builder.Property(oi => oi.SubTotal)
            .IsRequired();
        builder.Property(oi => oi.IsActive)
            .IsRequired();
        
        builder.HasOne(oi => oi.Bouquet)
            .WithMany(b => b.OrderItems)
            .HasForeignKey(oi => oi.BouquetId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}