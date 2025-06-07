using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class Feedback : EntityAuditBase<Guid>
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public bool IsActive { get; set; }
    
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    
    public Guid BouquetId { get; set; }
    public virtual Bouquet Bouquet { get; set; }
    
    public Guid OrderItemId { get; set; }
    public virtual OrderItem OrderItem { get; set; }
}