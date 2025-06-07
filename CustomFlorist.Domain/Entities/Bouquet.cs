using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class Bouquet : EntityAuditBase<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal BasePrice { get; set; }
    public string? Image { get; set; }
    public bool IsActive { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public virtual Category Category { get; set; }
    
    public virtual ICollection<BouquetComposition> BouquetCompositions { get; set; } = new List<BouquetComposition>();
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    
}