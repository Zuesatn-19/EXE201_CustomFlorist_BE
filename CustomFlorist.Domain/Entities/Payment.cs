using CustomFlorist.Domain.Entities.Common;
using CustomFlorist.Domain.Enums;

namespace CustomFlorist.Domain.Entities;

public class Payment : EntityAuditBase<Guid>
{
    public string TransactionCode { get; set; }
    public PaymentMethodEnum PaymentMethod { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatusEnum Status { get; set; }
    public bool IsActive { get; set; }
    
    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; }
}