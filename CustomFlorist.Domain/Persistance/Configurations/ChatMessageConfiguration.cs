using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.HasKey(cm => cm.Id);
        builder.Property(cm => cm.Content)
            .IsRequired();
        builder.Property(cm => cm.Timestamp)
            .IsRequired();
        builder.Property(cm => cm.IsFromUser)
            .IsRequired();
        builder.HasOne(ca => ca.ChatSession)
            .WithMany(cs => cs.ChatMessages)
            .HasForeignKey(cm => cm.ChatSessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}