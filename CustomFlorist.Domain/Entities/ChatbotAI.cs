using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class ChatbotAI : EntityBase<Guid>
{
    public string Query { get; set; }
    public string Response { get; set; }
    public DateTime Timestamp { get; set; }
    public bool IsActive { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public Guid ChatSessionId { get; set; }
    public virtual ChatSession ChatSession { get; set; }
}