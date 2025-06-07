using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class OrderBouquetFlower : EntityBase<Guid>
{
    public int Quantity { get; set; }
    
    public Guid FlowerId { get; set; }
    public virtual Flower Flower { get; set; }
    
    public Guid OrderItemId { get; set; }
    public virtual OrderItem OrderItem { get; set; }
    
}