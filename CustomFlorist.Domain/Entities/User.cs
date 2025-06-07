using CustomFlorist.Domain.Entities.Common;
using CustomFlorist.Domain.Enums;

namespace CustomFlorist.Domain.Entities;

public class User : EntityAuditBase<Guid>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string? Address { get; set; }
    public RoleEnum Role { get; set; }
    public int LoyaltyPoints { get; set; }
    public AccountStatusEnum AccountStatus { get; set; } = AccountStatusEnum.Active;
    public GenderEnum? Gender { get; set; }
    public string? VerificationCode { get; set; }
    public bool IsVerified { get; set; } = false;
    
    public virtual ICollection<ChatSession> ChatSessions { get; set; } = new List<ChatSession>();
    public virtual ICollection<DeliveryHistory> UserDeliveryHistories { get; set; } = new List<DeliveryHistory>();
    public virtual ICollection<DeliveryHistory> CourierDeliveryHistories { get; set; } = new List<DeliveryHistory>();
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<PromotionManager> PromotionManagers { get; set; } = new List<PromotionManager>();
}