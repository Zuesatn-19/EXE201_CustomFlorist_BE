using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class DeliveryHistory : EntityAuditBase<Guid>
{
    public string DeliveryCode { get; set; }
    public bool IsActive { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    
    public Guid CourierId { get; set; }
    public virtual User Courier { get; set; }
    
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; }
    
    public virtual ICollection<DeliveryStatusHistory> StatusHistories { get; set; } = new List<DeliveryStatusHistory>();
}