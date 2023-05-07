﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class SqlModelBuilder
{
    #region [ Singleton ]
    private static readonly Lazy<SqlModelBuilder> _current = new Lazy<SqlModelBuilder>(() => new SqlModelBuilder(), LazyThreadSafetyMode.PublicationOnly);
    public static SqlModelBuilder Current
    {
        get { return _current.Value; }
    }
    #endregion

    #region [ CTor ]
    public SqlModelBuilder()
    {

    }
    #endregion

    #region [ Public Methods ]
    public IModel GetModel()
    {
        var modelBuilder = new ModelBuilder();

        modelBuilder.Entity("WeAreMadeToHeal.BankCard", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<string>("BankFullName")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("BankShortName")
                .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("CreatedAt")
                .HasColumnType("datetime2");

            b.Property<DateTime>("CreatedDate")
                .HasColumnType("datetime2");

            b.Property<DateTime>("ExpiredDate")
                .HasColumnType("datetime2");

            b.Property<bool>("IsActive")
                .HasColumnType("bit");

            b.Property<string>("Number")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("OwnerName")
                .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime2");

            b.Property<string>("UserId")
                .HasColumnType("nvarchar(450)");

            b.HasKey("Id");

            b.HasIndex("UserId")
                .IsUnique()
                .HasFilter("[UserId] IS NOT NULL");

            b.ToTable("BankCards");
        });

        modelBuilder.Entity("WeAreMadeToHeal.CartItem", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<int>("Amount")
                .HasColumnType("int");

            b.Property<DateTime>("CreatedAt")
                .HasColumnType("datetime2");

            b.Property<bool>("IsActive")
                .HasColumnType("bit");

            b.Property<string>("ProductId")
                .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime2");

            b.Property<string>("UserId")
                .HasColumnType("nvarchar(450)");

            b.HasKey("Id");

            b.HasIndex("UserId");

            b.ToTable("CartItems");
        });

        modelBuilder.Entity("WeAreMadeToHeal.Category", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<DateTime>("CreatedAt")
                .HasColumnType("datetime2");

            b.Property<bool>("IsActive")
                .HasColumnType("bit");

            b.Property<string>("Name")
                .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime2");

            b.HasKey("Id");

            b.ToTable("Categories");
        });

        modelBuilder.Entity("WeAreMadeToHeal.Coupon", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<bool>("CanExpire")
                .HasColumnType("bit");

            b.Property<DateTime>("CreatedAt")
                .HasColumnType("datetime2");

            b.Property<string>("Description")
                .HasColumnType("nvarchar(max)");

            b.Property<int>("ExpiredAfterReceive")
                .HasColumnType("int");

            b.Property<DateTime>("ExpiredAt")
                .HasColumnType("datetime2");

            b.Property<bool>("IsActive")
                .HasColumnType("bit");

            b.Property<string>("MaxReduce")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Name")
                .HasColumnType("nvarchar(max)");

            b.Property<double>("ReduceAmount")
                .HasColumnType("float");

            b.Property<double>("ReduceRate")
                .HasColumnType("float");

            b.Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime2");

            b.HasKey("Id");

            b.ToTable("Coupons");
        });

        modelBuilder.Entity("WeAreMadeToHeal.CouponUser", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<int>("Amount")
                .HasColumnType("int");

            b.Property<string>("CouponId")
                .HasColumnType("nvarchar(450)");

            b.Property<DateTime>("CreatedAt")
                .HasColumnType("datetime2");

            b.Property<bool>("IsActive")
                .HasColumnType("bit");

            b.Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime2");

            b.Property<string>("UserId")
                .HasColumnType("nvarchar(450)");

            b.HasKey("Id");

            b.HasIndex("CouponId");

            b.HasIndex("UserId");

            b.ToTable("CouponUsers");
        });

        modelBuilder.Entity("WeAreMadeToHeal.Image", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<DateTime>("CreatedAt")
                .HasColumnType("datetime2");

            b.Property<bool>("IsActive")
                .HasColumnType("bit");

            b.Property<string>("ProductId")
                .HasColumnType("nvarchar(450)");

            b.Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime2");

            b.Property<string>("Url")
                .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.HasIndex("ProductId");

            b.ToTable("Images");
        });

        modelBuilder.Entity("WeAreMadeToHeal.Order", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<DateTime?>("ArriveDate")
                .HasColumnType("datetime2");

            b.Property<DateTime>("CreatedAt")
                .HasColumnType("datetime2");

            b.Property<DateTime?>("DepartDate")
                .HasColumnType("datetime2");

            b.Property<bool>("IsActive")
                .HasColumnType("bit");

            b.Property<bool>("IsArrive")
                .HasColumnType("bit");

            b.Property<bool>("IsPaid")
                .HasColumnType("bit");

            b.Property<double>("TotalPrice")
                .HasColumnType("float");

            b.Property<string>("UniqueCode")
                .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime2");

            b.Property<string>("UserId")
                .HasColumnType("nvarchar(450)");

            b.HasKey("Id");

            b.HasIndex("UserId");

            b.ToTable("Orders");
        });

        modelBuilder.Entity("WeAreMadeToHeal.OrderItem", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<int>("Amount")
                .HasColumnType("int");

            b.Property<DateTime>("CreatedAt")
                .HasColumnType("datetime2");

            b.Property<bool>("IsActive")
                .HasColumnType("bit");

            b.Property<string>("OrderId")
                .HasColumnType("nvarchar(450)");

            b.Property<string>("ProductId")
                .HasColumnType("nvarchar(450)");

            b.Property<double>("TotalPrice")
                .HasColumnType("float");

            b.Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime2");

            b.HasKey("Id");

            b.HasIndex("OrderId");

            b.HasIndex("ProductId");

            b.ToTable("OrderItems");
        });

        modelBuilder.Entity("WeAreMadeToHeal.Product", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<string>("CategoryId")
                .HasColumnType("nvarchar(450)");

            b.Property<string>("Color")
                .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("CreatedAt")
                .HasColumnType("datetime2");

            b.Property<bool>("IsActive")
                .HasColumnType("bit");

            b.Property<string>("Name")
                .HasColumnType("nvarchar(max)");

            b.Property<double>("Price")
                .HasColumnType("float");

            b.Property<string>("Size")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Story")
                .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime2");

            b.HasKey("Id");

            b.HasIndex("CategoryId");

            b.ToTable("Products");
        });

        modelBuilder.Entity("WeAreMadeToHeal.Tag", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<DateTime>("CreatedAt")
                .HasColumnType("datetime2");

            b.Property<bool>("IsActive")
                .HasColumnType("bit");

            b.Property<string>("Name")
                .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime2");

            b.HasKey("Id");

            b.ToTable("Tags");
        });

        modelBuilder.Entity("WeAreMadeToHeal.TagProduct", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<DateTime>("CreatedAt")
                .HasColumnType("datetime2");

            b.Property<bool>("IsActive")
                .HasColumnType("bit");

            b.Property<string>("ProductId")
                .HasColumnType("nvarchar(450)");

            b.Property<string>("TagId")
                .HasColumnType("nvarchar(450)");

            b.Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime2");

            b.HasKey("Id");

            b.HasIndex("ProductId");

            b.HasIndex("TagId");

            b.ToTable("TagProducts");
        });

        modelBuilder.Entity("WeAreMadeToHeal.User", b =>
        {
            b.Property<string>("Id")
                .HasColumnType("nvarchar(450)");

            b.Property<int>("AccessFailedCount")
                .HasColumnType("int");

            b.Property<string>("Address")
                .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("Birthday")
                .HasColumnType("datetime2");

            b.Property<string>("ConcurrencyStamp")
                .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("CreatedAt")
                .HasColumnType("datetime2");

            b.Property<string>("Email")
                .HasColumnType("nvarchar(max)");

            b.Property<bool>("EmailConfirmed")
                .HasColumnType("bit");

            b.Property<bool>("IsActive")
                .HasColumnType("bit");

            b.Property<bool>("LockoutEnabled")
                .HasColumnType("bit");

            b.Property<DateTimeOffset?>("LockoutEnd")
                .HasColumnType("datetimeoffset");

            b.Property<string>("Name")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("NormalizedEmail")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("NormalizedUserName")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("PasswordHash")
                .HasColumnType("nvarchar(max)");

            b.Property<string>("PhoneNumber")
                .HasColumnType("nvarchar(max)");

            b.Property<bool>("PhoneNumberConfirmed")
                .HasColumnType("bit");

            b.Property<int>("Role")
                .HasColumnType("int");

            b.Property<string>("SecurityStamp")
                .HasColumnType("nvarchar(max)");

            b.Property<bool>("TwoFactorEnabled")
                .HasColumnType("bit");

            b.Property<DateTime>("UpdatedAt")
                .HasColumnType("datetime2");

            b.Property<string>("UserName")
                .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.ToTable("Users");
        });

        modelBuilder.Entity("WeAreMadeToHeal.BankCard", b =>
        {
            b.HasOne("WeAreMadeToHeal.User", null)
                .WithOne("BankCard")
                .HasForeignKey("WeAreMadeToHeal.BankCard", "UserId")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity("WeAreMadeToHeal.CartItem", b =>
        {
            b.HasOne("WeAreMadeToHeal.User", null)
                .WithMany("CartItems")
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity("WeAreMadeToHeal.CouponUser", b =>
        {
            b.HasOne("WeAreMadeToHeal.Coupon", "Coupon")
                .WithMany("CouponUsers")
                .HasForeignKey("CouponId")
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne("WeAreMadeToHeal.User", "User")
                .WithMany("CouponUsers")
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);

            b.Navigation("Coupon");

            b.Navigation("User");
        });

        modelBuilder.Entity("WeAreMadeToHeal.Image", b =>
        {
            b.HasOne("WeAreMadeToHeal.Product", null)
                .WithMany("Images")
                .HasForeignKey("ProductId")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity("WeAreMadeToHeal.Order", b =>
        {
            b.HasOne("WeAreMadeToHeal.User", null)
                .WithMany("Orders")
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.SetNull);
        });

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

        modelBuilder.Entity("WeAreMadeToHeal.Product", b =>
        {
            b.HasOne("WeAreMadeToHeal.Category", null)
                .WithMany("Products")
                .HasForeignKey("CategoryId");
        });

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

        modelBuilder.Entity("WeAreMadeToHeal.Category", b =>
        {
            b.Navigation("Products");
        });

        modelBuilder.Entity("WeAreMadeToHeal.Coupon", b =>
        {
            b.Navigation("CouponUsers");
        });

        modelBuilder.Entity("WeAreMadeToHeal.Order", b =>
        {
            b.Navigation("OrderItems");
        });

        modelBuilder.Entity("WeAreMadeToHeal.Product", b =>
        {
            b.Navigation("Images");

            b.Navigation("TagProducts");
        });

        modelBuilder.Entity("WeAreMadeToHeal.Tag", b =>
        {
            b.Navigation("TagProducts");
        });

        modelBuilder.Entity("WeAreMadeToHeal.User", b =>
        {
            b.Navigation("BankCard");

            b.Navigation("CartItems");

            b.Navigation("CouponUsers");

            b.Navigation("Orders");
        });

        return modelBuilder.FinalizeModel();
    }
    #endregion
}
