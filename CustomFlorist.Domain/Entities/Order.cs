using CustomFlorist.Domain.Entities.Common;
using CustomFlorist.Domain.Enums;

namespace CustomFlorist.Domain.Entities;

public class Order : EntityAuditBase<Guid>
{
    public DateTime OrderDate { get; set; }
    
    public string? Reason { get; set; }
    public OrderStatusEnum Status { get; set; }
    public decimal TotalPrice { get; set; }
    public string ShippingAddress { get; set; }
    public bool IsActive { get; set; }
    
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    
    public Guid? PromotionId { get; set; }
    public virtual Promotion? Promotion { get; set; }
    
    public virtual ICollection<DeliveryHistory> DeliveryHistories { get; set; } = new List<DeliveryHistory>();
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}