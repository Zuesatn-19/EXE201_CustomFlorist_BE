using System.Reflection;
using CustomFlorist.Domain.Entities;
using CustomFlorist.Domain.Entities.Common.Interface;
using Microsoft.EntityFrameworkCore;

namespace CustomFlorist.Domain.Persistance;

public class CustomFloristContext : DbContext
{
    public CustomFloristContext() {}
    
    public CustomFloristContext(DbContextOptions<CustomFloristContext> options) : base(options)
    {
    }
    
    public DbSet<Bouquet> Bouquet { get; set; }
    public DbSet<BouquetComposition> BouquetComposition { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<ChatbotAI> ChatbotAI { get; set; }
    public DbSet<ChatMessage> ChatMessage { get; set; }
    public DbSet<ChatSession> ChatSession { get; set; }
    public DbSet<DeliveryHistory> DeliveryHistory { get; set; }
    public DbSet<DeliveryStatusHistory> DeliveryStatusHistory { get; set; }
    public DbSet<Feedback> Feedback { get; set; }
    public DbSet<Flower> Flower { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderBouquetFlower> OrderBouquetFlower { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Promotion> Promotion { get; set; }
    public DbSet<PromotionManager> PromotionManager { get; set; }
    public DbSet<User> User { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var modified = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified ||
                        e.State == EntityState.Added ||
                        e.State == EntityState.Deleted);

        foreach (var item in modified)
            switch (item.State)
            {
                case EntityState.Added:
                    if (item.Entity is IDateTracking addedEntity)
                    {
                        addedEntity.CreatedDate = DateTime.UtcNow;
                        item.State = EntityState.Added;
                    }

                    break;
                case EntityState.Modified:
                    if (item.Entity is IDateTracking modifiedEntity)
                    {
                        Entry(item.Entity).Property("Id").IsModified = false;
                        modifiedEntity.LastModifiedDate = DateTime.UtcNow;
                        item.State = EntityState.Modified;
                    }

                    break;
            }

        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
}