using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class PromotionManagerConfiguration : IEntityTypeConfiguration<PromotionManager>
{
    public void Configure(EntityTypeBuilder<PromotionManager> builder)
    {
        builder.HasKey(pm => pm.Id);

        builder.Property(pm => pm.Quantity)
            .IsRequired();
        
        builder.HasOne(pm => pm.User)
            .WithMany(u => u.PromotionManagers)
            .HasForeignKey(pm => pm.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(pm => pm.Promotion)
            .WithMany(p => p.PromotionManagers)
            .HasForeignKey(pm => pm.PromotionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}