using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired();
        builder.Property(c => c.Description)
            .IsRequired();
        builder.Property(c => c.IsActive)
            .IsRequired();
    }
}