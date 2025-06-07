using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class PromotionManager : EntityBase<Guid>
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    
    public Guid PromotionId { get; set; }
    public virtual Promotion Promotion { get; set; }
    
    public int Quantity { get; set; }
}