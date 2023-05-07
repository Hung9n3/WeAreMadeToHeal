using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeAreMadeToHeal.Enums;

namespace WeAreMadeToHeal;

public class SeedProvider
{
    #region [ Singleton ]
    private static readonly Lazy<SeedProvider> _current = new Lazy<SeedProvider>(() => new SeedProvider(), LazyThreadSafetyMode.PublicationOnly);

    public static SeedProvider Current
    {
        get { return _current.Value; }
    }
    #endregion

    #region [ CTor ]
    public SeedProvider()
    {
        // init
        this.Users = new List<User>();
        this.Coupons = new List<Coupon>();
        this.CouponUsers = new List<CouponUser>();
        this.Categories = new List<Category>();
        this.CartItems = new List<CartItem>();
        this.Tags = new List<Tag>();
        this.TagProducts = new List<TagProduct>();
        this.Roles = new List<Role>();
        this.BankCards = new List<BankCard>();
        this.Images = new List<Image>();
        this.OrderItems = new List<OrderItem>();
        this.Orders = new List<Order>();
        this.Products = new List<Product>();


        this.Clear();
        this.Load();
    }
    #endregion

    #region [ Properties ]
    public List<User> Users { get; private set; }

    public List<Coupon> Coupons { get; private set; }

    public List<Category> Categories { get; private set; }

    public List<Tag> Tags { get; private set; }

    public List<BankCard> BankCards { get; private set; }

    public List<CartItem> CartItems { get; private set; }

    public List<CouponUser> CouponUsers { get; private set; }

    public List<Image> Images { get; private set; }

    public List<Order> Orders { get; private set; }

    public List<OrderItem> OrderItems { get; private set; }

    public List<TagProduct> TagProducts { get; private set; }

    public List<Product> Products { get; private set; }

    public List<Role> Roles { get; private set; }


    #endregion

    #region [ Private Methods - Populate Data ]
    private void Load()
    {
        #region[User]
        this.Users.Add(new User()
        {
            Id = "1",
            Email = "chovameo352@gmail.com",
            Name = "customer 1",
            UserName = "customer1",
            Role = UserRoles.Customer,
            PasswordHash = "AQAAAAIAAYagAAAAEIUC+pqIvFHEUAE17ledIw+SCgRPdXcny9lYXAFjjv+MEWSvj13NgQGCV9v80ikO+w==",
        });

        this.Users.Add(new User()
        {
            Id = "2",
            Email = "skvuahung1@gmail.com",
            Name = "customer 2",
            UserName = "customer2",
            Role = UserRoles.Customer,
            PasswordHash = "AQAAAAIAAYagAAAAEIUC+pqIvFHEUAE17ledIw+SCgRPdXcny9lYXAFjjv+MEWSvj13NgQGCV9v80ikO+w==",
        });

        this.Users.Add(new User()
        {
            Id = "3",
            Email = "doduyhung261200@gmail.com",
            Name = "admin 1",
            UserName = "admin",
            Role = UserRoles.Admin,
            PasswordHash = "AQAAAAIAAYagAAAAEIUC+pqIvFHEUAE17ledIw+SCgRPdXcny9lYXAFjjv+MEWSvj13NgQGCV9v80ikO+w==",
        });
        #endregion

        #region [Categories]
        this.Categories.Add(new Category()
        {
            Id = "1",
            Name = "Category1",
        });
        this.Categories.Add(new Category()
        {
            Id = "2",
            Name = "Category2",
        });
        this.Categories.Add(new Category()
        {
            Id = "3",
            Name = "Category3",
        });
        this.Categories.Add(new Category()
        {
            Id = "4",
            Name = "Category4",
        });
        this.Categories.Add(new Category()
        {
            Id = "5",
            Name = "Category5",
        });
        #endregion


        #region [Tags]
        this.Tags.Add(new Tag()
        {
            Id = "1",
            Name = "Tag1",
        });
        this.Tags.Add(new Tag()
        {
            Id = "2",
            Name = "Tag2",
        });
        this.Tags.Add(new Tag()
        {
            Id = "3",
            Name = "Tag3",
        });
        this.Tags.Add(new Tag()
        {
            Id = "4",
            Name = "Tag4",
        });
        this.Tags.Add(new Tag()
        {
            Id = "5",
            Name = "Tag5",
        });
        #endregion

        #region [Products]
        this.Products.Add(new Product()
        {
            Id = "1",
            Name = "Product1",
            Amount = 1000,
            Price = 10,
            CategoryId = "1",
        });
        this.Products.Add(new Product()
        {
            Id = "2",
            Name = "Product2",
            Amount = 1000,
            Price = 20,
            CategoryId = "2",
        });
        #endregion

        #region [TagProducts]
        this.TagProducts.Add(new TagProduct()
        {
            Id = "1",
            ProductId = "1",
            TagId = "1",
        });
        this.TagProducts.Add(new TagProduct()
        {
            Id = "2",
            ProductId = "2",
            TagId = "2",
        });
        this.TagProducts.Add(new TagProduct()
        {
            Id = "3",
            ProductId = "1",
            TagId = "2"
        });
        this.TagProducts.Add(new TagProduct()
        {
            Id = "4",
            ProductId = "1",
            TagId = "4",
        });
        this.TagProducts.Add(new TagProduct()
        {
            Id = "5",
            ProductId = "2",
            TagId = "5"
        });
        #endregion

        #region [Image]
        this.Images.Add(new Image()
        {
            Id = "1",
            Url= "",
            ProductId = "1",
        });
        this.Images.Add(new Image()
        {
            Id = "2",
            Url = "",
            ProductId = "2",
        });
        this.Images.Add(new Image()
        {
            Id = "3",
            Url = "",
            ProductId = "2",
        });
        this.Images.Add(new Image()
        {
            Id = "4",
            Url = "",
            ProductId = "1",
        });
        this.Images.Add(new Image()
        {
            Id = "5",
            Url = "",
            ProductId = "2",
        });
        #endregion

        #region [CartItem]
        this.CartItems.Add(new CartItem()
        {
            Id = "1",
            UserId = "1",
            Amount = 1,
            ProductId = "1",
        });
        this.CartItems.Add(new CartItem()
        {
            Id = "2",
            UserId = "2",
            Amount = 2,
            ProductId = "2",
        });
        this.CartItems.Add(new CartItem()
        {
            Id = "3",
            UserId = "1",
            Amount = 3,
            ProductId = "2",
        });
        this.CartItems.Add(new CartItem()
        {
            Id = "4",
            UserId = "2",
            Amount = 4,
            ProductId = "1",
        });
        #endregion

        #region [Order]
        this.Orders.Add(new Order()
        {
            Id = "1",
            TotalPrice = 10,
            UserId = "1",
            IsArrive= true,
            IsPaid= true,
        });
        this.Orders.Add(new Order()
        {
            Id = "2",
            TotalPrice = 50,
            UserId = "1",
            IsArrive = true,
            IsPaid = true,
        });
        this.Orders.Add(new Order()
        {
            Id = "3",
            TotalPrice = 30,
            UserId = "2",
            IsArrive = false,
            IsPaid = false,
        });
        #endregion

        #region [OrderItem]
        this.OrderItems.Add(new OrderItem() 
        {
            Id = "1",
            ProductId = "1",
            OrderId = "1",
            Amount = 1,
            TotalPrice = 10,
        });
        this.OrderItems.Add(new OrderItem()
        {
            Id = "2",
            ProductId = "1",
            OrderId = "2",
            Amount = 1,
            TotalPrice = 10,
        });
        this.OrderItems.Add(new OrderItem()
        {
            Id = "3",
            ProductId = "2",
            OrderId = "2",
            Amount = 2,
            TotalPrice = 40,
        });
        this.OrderItems.Add(new OrderItem()
        {
            Id = "4",
            ProductId = "1",
            OrderId = "3",
            Amount = 3,
            TotalPrice = 30,
        });
        #endregion

        #region [BankCard]
        this.BankCards.Add(new BankCard()
        {
            Id = "1",
            BankFullName = "Tien Phong Bank",
            BankShortName = "TpBank",
            OwnerName = "customer 1",
            Number = "",
            ExpiredDate = DateTime.Now.AddYears(100),
            CreatedDate = DateTime.Now.AddYears(-5),
            UserId = "1",
        });
        #endregion

        #region [Coupon]
        this.Coupons.Add(new Coupon() 
        { 
            Id = "1",
            Name = "New Customer Voucher",
            ReduceRate = 10
        });
        #endregion

        #region [CouponUser]
        this.CouponUsers.Add(new CouponUser()
        {
            Id = "1",
            UserId = "1",
            CouponId = "1",
        });
        this.CouponUsers.Add(new CouponUser()
        {
            Id = "2",
            UserId = "2",
            CouponId = "1",
        });
        #endregion

        #region [Role]
        this.Roles.Add(new Role()
        {
            Id = "1",
            Name = "Admin"
        });
        this.Roles.Add(new Role()
        {
            Id = "2",
            Name = "Customer"
        });
        #endregion

    }

    private void Clear()
    {
        this.Users = new List<User>();
        this.Coupons = new List<Coupon>();
        this.CouponUsers = new List<CouponUser>();
        this.Categories = new List<Category>();
        this.CartItems = new List<CartItem>();
        this.Tags = new List<Tag>();
        this.TagProducts = new List<TagProduct>();
        this.Roles = new List<Role>();
        this.BankCards = new List<BankCard>();
        this.Images = new List<Image>();
        this.OrderItems = new List<OrderItem>();
        this.Orders = new List<Order>();
        this.Products = new List<Product>();
    }
    #endregion
}
