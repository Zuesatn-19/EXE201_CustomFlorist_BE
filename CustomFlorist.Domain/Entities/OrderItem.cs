using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class OrderItem : EntityBase<Guid>
{
    public int Quantity { get; set; }
    public decimal SubTotal { get; set; }
    public bool IsActive { get; set; }
    
    public Guid BouquetId { get; set; }
    public virtual Bouquet Bouquet { get; set; }
    
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; }
    
    public virtual ICollection<OrderBouquetFlower> OrderBouquetFlowers { get; set; } = new List<OrderBouquetFlower>();
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}