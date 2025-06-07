using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class ChatSession : EntityAuditBase<Guid>
{
    public DateTime LastActivity { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();
}