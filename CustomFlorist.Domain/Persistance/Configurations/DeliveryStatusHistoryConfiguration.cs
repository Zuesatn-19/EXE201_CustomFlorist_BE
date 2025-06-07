using CustomFlorist.Domain.Entities;
using CustomFlorist.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class DeliveryStatusHistoryConfiguration : IEntityTypeConfiguration<DeliveryStatusHistory>
{
    public void Configure(EntityTypeBuilder<DeliveryStatusHistory> builder)
    {
        builder.HasKey(dsh => dsh.Id);

        builder.Property(i => i.Status)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (DeliveryStatusEnum)Enum.Parse(typeof(DeliveryStatusEnum), v)
            );
        builder.HasOne(dsh => dsh.DeliveryHistory)
            .WithMany(dh => dh.StatusHistories)
            .HasForeignKey(dsh => dsh.DeliveryHistoryId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}