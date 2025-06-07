using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class DeliveryHistoryConfiguration : IEntityTypeConfiguration<DeliveryHistory>
{
    public void Configure(EntityTypeBuilder<DeliveryHistory> builder)
    {
        builder.HasKey(dh => dh.Id);
        
        builder.HasIndex(dh => dh.DeliveryCode)
            .IsUnique();
        builder.Property(dh => dh.DeliveryCode)
            .IsRequired();
        builder.Property(dh => dh.IsActive)
            .IsRequired();
        builder.HasOne(dh => dh.User)
            .WithMany(u => u.UserDeliveryHistories)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(dh => dh.Courier)
            .WithMany(c => c.CourierDeliveryHistories)
            .HasForeignKey(dh => dh.CourierId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(dh => dh.Order)
            .WithMany(o => o.DeliveryHistories)
            .HasForeignKey(dh => dh.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}