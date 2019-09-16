﻿// <auto-generated />
using System;
using CrazyPetals.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrazyPetals.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CrazyPetals.Entities.Database.ActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<int>("ApplicationUserId");

                    b.Property<string>("Task");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ActivityLog");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.AppTheme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<string>("AppLogo");

                    b.Property<string>("AppName");

                    b.Property<string>("CurrencySymbols");

                    b.Property<string>("PrimaryColor");

                    b.Property<string>("SecondryColor");

                    b.Property<string>("StatusBarColor");

                    b.Property<string>("TextColor");

                    b.HasKey("Id");

                    b.ToTable("AppTheme");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Name");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("ProfilePicture");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("ExpiryDate");

                    b.Property<string>("Image");

                    b.Property<string>("RedirectClick");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Banner");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.CartDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<int>("ApplicationUserId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Colors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<string>("HashCode");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Delivery_charge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId");

                    b.Property<string>("CreatedDate");

                    b.Property<int>("DeliveryCharge");

                    b.Property<int>("Max");

                    b.Property<int>("Min");

                    b.HasKey("Id");

                    b.ToTable("delivery_Charges");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.ExternalLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppId")
                        .HasMaxLength(30);

                    b.Property<int>("LoginProvider");

                    b.Property<int>("ProviderKey");

                    b.HasKey("Id");

                    b.ToTable("ExternalLogin");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Filter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Filter");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.ForgotPassword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<int>("ApplicationUserId");

                    b.Property<DateTime>("ExpireDate");

                    b.Property<bool>("IsUsed");

                    b.Property<string>("OTP");

                    b.Property<string>("VerificationCode");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ForgotPassword");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Message");

                    b.Property<string>("Platform");

                    b.Property<string>("Redirect");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApplicationUserId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("DeliveryCharges");

                    b.Property<decimal>("DiscountPrice");

                    b.Property<decimal>("GSTPrice");

                    b.Property<int>("MRP");

                    b.Property<string>("OrderNumber");

                    b.Property<decimal>("SubTotalPrice");

                    b.Property<decimal>("TotalPrice");

                    b.Property<int>("UserAddressId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UserAddressId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiscountedPrice");

                    b.Property<int>("OrderId");

                    b.Property<int>("OriginalPrice");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DeliveryTime");

                    b.Property<string>("Description");

                    b.Property<string>("Dimension");

                    b.Property<int>("DiscountPercentage");

                    b.Property<int>("DiscountedPrice");

                    b.Property<int?>("FilterId");

                    b.Property<string>("IncludedAccessories");

                    b.Property<bool>("IsAvailable");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsExclusive");

                    b.Property<bool>("IsPublish");

                    b.Property<string>("MaterialType");

                    b.Property<string>("Name");

                    b.Property<int>("OriginalPrice");

                    b.Property<string>("Precautions");

                    b.Property<string>("Size");

                    b.Property<int>("StockKeepingUnit");

                    b.Property<string>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FilterId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.ProductColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorsId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ColorsId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductColor");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.ProductImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<string>("Image");

                    b.Property<bool>("IsMain");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.ProductSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId");

                    b.Property<int>("SizeId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("ProductSize");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<string>("ProductSize");

                    b.Property<string>("Unit");

                    b.HasKey("Id");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.SmtpMail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<string>("Description");

                    b.Property<string>("DisplayName");

                    b.Property<string>("FromMail");

                    b.Property<string>("Host");

                    b.Property<int>("Port");

                    b.Property<string>("SmtpPassword");

                    b.HasKey("Id");

                    b.ToTable("SmtpMail");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<int>("ApplicationUserId");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Locality");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("PINCode");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("UserAddress");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.VersionControl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppId")
                        .HasMaxLength(30);

                    b.Property<bool>("CurrentLiveVersion");

                    b.Property<DateTime>("Date");

                    b.Property<string>("UpdateType");

                    b.Property<float>("VersionNumber");

                    b.HasKey("Id");

                    b.ToTable("VersionControl");
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.ActivityLog", b =>
                {
                    b.HasOne("CrazyPetals.Entities.Database.ApplicationUser", "ApplicationUser")
                        .WithMany("ActivityLogs")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.ApplicationUser", b =>
                {
                    b.HasOne("CrazyPetals.Entities.Database.Role", "Role")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.CartDetails", b =>
                {
                    b.HasOne("CrazyPetals.Entities.Database.ApplicationUser", "ApplicationUser")
                        .WithMany("CartDetails")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrazyPetals.Entities.Database.Product", "Product")
                        .WithMany("CartDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Filter", b =>
                {
                    b.HasOne("CrazyPetals.Entities.Database.Category", "Category")
                        .WithMany("Filters")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.ForgotPassword", b =>
                {
                    b.HasOne("CrazyPetals.Entities.Database.ApplicationUser", "ApplicationUser")
                        .WithMany("ForgotPasswords")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Order", b =>
                {
                    b.HasOne("CrazyPetals.Entities.Database.ApplicationUser", "ApplicationUser")
                        .WithMany("Orders")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrazyPetals.Entities.Database.UserAddress", "UserAddress")
                        .WithMany("Orders")
                        .HasForeignKey("UserAddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.OrderDetails", b =>
                {
                    b.HasOne("CrazyPetals.Entities.Database.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrazyPetals.Entities.Database.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.Product", b =>
                {
                    b.HasOne("CrazyPetals.Entities.Database.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CrazyPetals.Entities.Database.Filter", "Filter")
                        .WithMany("Products")
                        .HasForeignKey("FilterId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.ProductColor", b =>
                {
                    b.HasOne("CrazyPetals.Entities.Database.Colors", "Colors")
                        .WithMany("ProductColors")
                        .HasForeignKey("ColorsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrazyPetals.Entities.Database.Product", "Product")
                        .WithMany("ProductColors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.ProductImages", b =>
                {
                    b.HasOne("CrazyPetals.Entities.Database.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.ProductSize", b =>
                {
                    b.HasOne("CrazyPetals.Entities.Database.Product", "Product")
                        .WithMany("ProductSizes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CrazyPetals.Entities.Database.Size", "Size")
                        .WithMany("ProductSizes")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CrazyPetals.Entities.Database.UserAddress", b =>
                {
                    b.HasOne("CrazyPetals.Entities.Database.ApplicationUser", "ApplicationUser")
                        .WithMany("UserAddresses")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
