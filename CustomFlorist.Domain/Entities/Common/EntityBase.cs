
using CustomFlorist.Domain.Entities.Common.Interface;

namespace CustomFlorist.Domain.Entities.Common;

public class EntityBase<TKey> : IEntityBase<TKey>
{
    public TKey Id { get; set; }
}