using CustomFlorist.Domain.Entities.Common;
using CustomFlorist.Domain.Enums;

namespace CustomFlorist.Domain.Entities;

public class DeliveryStatusHistory : EntityAuditBase<Guid>
{
    public DeliveryStatusEnum Status { get; set; }
    public string? Note { get; set; }
    
    public Guid DeliveryHistoryId { get; set; }
    public virtual DeliveryHistory DeliveryHistory { get; set; }
}