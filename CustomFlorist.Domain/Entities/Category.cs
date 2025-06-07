using CustomFlorist.Domain.Entities.Common;

namespace CustomFlorist.Domain.Entities;

public class Category : EntityBase<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    
    public virtual ICollection<Bouquet> Bouquets { get; set; } = new List<Bouquet>();
}