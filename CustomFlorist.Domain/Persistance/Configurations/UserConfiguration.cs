using CustomFlorist.Domain.Entities;
using CustomFlorist.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email)
            .IsRequired();
        builder.HasIndex(u => u.Email)
            .IsUnique();
        builder.Property(u => u.Password)
            .IsRequired();
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(u => u.Phone)
            .IsRequired()
            .HasMaxLength(20);
        builder.HasIndex(u => u.Phone)
            .IsUnique();
        builder.Property(u => u.Address)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(u => u.Role)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (RoleEnum)Enum.Parse(typeof(RoleEnum), v)
            );
        builder.Property(u => u.LoyaltyPoints)
            .IsRequired();
        builder.Property(u => u.AccountStatus)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => (AccountStatusEnum)Enum.Parse(typeof(AccountStatusEnum), v)
            );
        builder.Property(u => u.Gender)
            .HasConversion(
                v => v.ToString(),
                v => (GenderEnum)Enum.Parse(typeof(GenderEnum), v)
            );
        builder.Property(u => u.IsVerified)
            .IsRequired();
    }
}