using CustomFlorist.Domain.Entities;
using CustomFlorist.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.TransactionCode)
            .IsUnique();
        builder.Property(p => p.TransactionCode)
            .IsRequired();
        
        builder.Property(p => p.PaymentMethod)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (PaymentMethodEnum)Enum.Parse(typeof(PaymentMethodEnum), v)
            );

        builder.Property(p => p.PaymentDate)
            .IsRequired();

        builder.Property(p => p.Amount)
            .IsRequired();
        builder.Property(p => p.Status)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (PaymentStatusEnum)Enum.Parse(typeof(PaymentStatusEnum), v)
            );
        builder.Property(p => p.IsActive)
            .IsRequired();
        
        builder.HasOne(p => p.Order)
            .WithMany(o => o.Payments)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}