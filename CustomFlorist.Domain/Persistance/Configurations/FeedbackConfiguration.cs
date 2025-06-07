using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Rating)
            .IsRequired();
        builder.Property(f => f.Comment)
            .IsRequired();
        builder.Property(f => f.IsActive)
            .IsRequired();
        builder.HasOne(f => f.User)
            .WithMany(u => u.Feedbacks)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(f => f.Bouquet)
            .WithMany(b => b.Feedbacks)
            .HasForeignKey(f => f.BouquetId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(f => f.OrderItem)
            .WithMany(oi => oi.Feedbacks)
            .HasForeignKey(f => f.OrderItemId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}