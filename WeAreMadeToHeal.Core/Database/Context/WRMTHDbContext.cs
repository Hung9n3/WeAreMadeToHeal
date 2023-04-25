using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public DbSet<TagProduct> TagProducts { get; set; }
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //BankCard
            modelBuilder.Entity("WeAreMadeToHeal.BankCard", b =>
            {
                b.HasOne("WeAreMadeToHeal.User", null)
                    .WithOne("BankCard")
                    .HasForeignKey("WeAreMadeToHeal.BankCard", "UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            //Cart Item
            modelBuilder.Entity("WeAreMadeToHeal.CartItem", b =>
            {
                b.HasOne("WeAreMadeToHeal.User", null)
                    .WithMany("CartItems")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            //Coupon User
            modelBuilder.Entity("WeAreMadeToHeal.CouponUser", b =>
            {
                b.HasOne("WeAreMadeToHeal.Coupon", "Coupon")
                    .WithMany("CouponUsers")
                    .HasForeignKey("CouponId")
                    .OnDelete(DeleteBehavior.Cascade); ;

                b.HasOne("WeAreMadeToHeal.User", "User")
                    .WithMany("CouponUsers")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.Navigation("Coupon");

                b.Navigation("User");
            });

            //Order
            modelBuilder.Entity("WeAreMadeToHeal.Order", b =>
            {
                b.HasOne("WeAreMadeToHeal.User", null)
                    .WithMany("Orders")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            //Order Item
            modelBuilder.Entity("WeAreMadeToHeal.OrderItem", b =>
            {
                b.HasOne("WeAreMadeToHeal.Order", null)
                    .WithMany("OrderItems")
                    .HasForeignKey("OrderId");

                b.HasOne("WeAreMadeToHeal.Product", "Product")
                    .WithMany()
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.SetNull);

                b.Navigation("Product");
            });

            //Tag Product
            modelBuilder.Entity("WeAreMadeToHeal.TagProduct", b =>
            {
                b.HasOne("WeAreMadeToHeal.Product", "Product")
                    .WithMany("TagProducts")
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne("WeAreMadeToHeal.Tag", "Tag")
                    .WithMany("TagProducts")
                    .HasForeignKey("TagId")
                    .OnDelete(DeleteBehavior.Cascade);

                b.Navigation("Product");

                b.Navigation("Tag");
            });

            //Image
            modelBuilder.Entity("WeAreMadeToHeal.Image", b =>
            {
                b.HasOne("WeAreMadeToHeal.Product", null)
                    .WithMany("Images")
                    .HasForeignKey("ProductId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
        #endregion
    }
}
