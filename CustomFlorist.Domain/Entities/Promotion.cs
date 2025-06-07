using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class Promotion : EntityAuditBase<Guid>
{
    public string PromotionCode { get; set; }
    public decimal DiscountPercentage { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public bool IsActive { get; set; }
    
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<PromotionManager> PromotionManagers { get; set; } = new List<PromotionManager>();
}