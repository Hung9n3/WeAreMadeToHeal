using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class WRMTHDbContext : DbContext
    {
        public WRMTHDbContext(DbContextOptions<WRMTHDbContext> options) : base(options)
        {
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<BankCard>  BankCards { get; set; }
        public DbSet<Product > Products { get; set; }
        public DbSet<TagProduct> TagsProduct { get; set; }
        public DbSet<CouponUser> CouponUsers { get; set; }
        #region [ Public Overridden Methods ]
        public override int SaveChanges()
        {
            var changedEntities = this.ChangeTracker.Entries()
                                                    .Where(x => x.State == EntityState.Added
                                                             || x.State == EntityState.Modified);
            foreach (var entity in changedEntities)
            {
                var dateTimeOffset = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    entity.Property(nameof(BaseEntity.CreatedAt)).CurrentValue = dateTimeOffset;
                }
                entity.Property(nameof(BaseEntity.UpdatedAt)).CurrentValue = dateTimeOffset;
            }
            return base.SaveChanges();
        }
        #endregion
    }
}
