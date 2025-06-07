using CustomFlorist.Domain.Entities;
using CustomFlorist.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.OrderDate)
            .IsRequired();
        builder.Property(o => o.Status)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (OrderStatusEnum)Enum.Parse(typeof(OrderStatusEnum), v)
            );
        builder.Property(o => o.TotalPrice)
            .IsRequired();
        builder.Property(o => o.ShippingAddress)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(o => o.IsActive)
            .IsRequired();
        builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(o => o.Promotion)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.PromotionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}