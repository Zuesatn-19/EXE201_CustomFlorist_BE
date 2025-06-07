using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class ChatbotAIConfiguration : IEntityTypeConfiguration<ChatbotAI>
{
    public void Configure(EntityTypeBuilder<ChatbotAI> builder)
    {
        builder.HasKey(ca => ca.Id);

        builder.Property(ca => ca.Query)
            .IsRequired();

        builder.Property(ca => ca.Response)
            .IsRequired();

        builder.Property(ca => ca.Timestamp)
            .IsRequired();
        builder.Property(ca => ca.IsActive)
            .IsRequired();
    }
}