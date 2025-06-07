using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class BouquetComposition : EntityAuditBase<Guid>
{
    public int? MinQuantity { get; set; }
    public int? MaxQuantity { get; set; }
    public int Quantity { get; set; }
    public bool IsActive { get; set; }
    
    public Guid BouquetId { get; set; }
    public virtual Bouquet Bouquet { get; set; }
    
    public Guid FlowerId { get; set; }
    public virtual Flower Flower { get; set; }
    
}