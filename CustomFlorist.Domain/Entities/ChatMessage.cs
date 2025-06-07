using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class ChatMessage : EntityBase<Guid>
{
    public string Content { get; set; }
    public bool IsFromUser { get; set; }
    public DateTime Timestamp { get; set; }
    
    public Guid ChatSessionId { get; set; }
    public ChatSession ChatSession { get; set; } 
}