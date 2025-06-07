using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class Flower : EntityAuditBase<Guid>
{
    public string Name { get; set; }
    public string FlowerType { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public bool IsActive { get; set; }
    
    public virtual ICollection<BouquetComposition> BouquetCompositions { get; set; } = new List<BouquetComposition>();
    public virtual ICollection<OrderBouquetFlower> OrderBouquetFlowers { get; set; } = new List<OrderBouquetFlower>();

}