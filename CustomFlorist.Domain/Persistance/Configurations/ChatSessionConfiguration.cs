using CustomFlorist.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomFlorist.Domain.Persistance.Configurations;

public class ChatSessionConfiguration : IEntityTypeConfiguration<ChatSession>
{
    public void Configure(EntityTypeBuilder<ChatSession> builder)
    {
        builder.HasKey(cs => cs.Id);

        builder.Property(cs => cs.LastActivity)
            .IsRequired();

        builder.HasOne(cs => cs.User)
            .WithMany(u => u.ChatSessions)
            .HasForeignKey(cs => cs.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}