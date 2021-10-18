﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Promocodes.Data.Persistence;

namespace Promocodes.Data.Persistence.Migrations
{
    [DbContext(typeof(PromocodesDbContext))]
    [Migration("20211018093249_AddAdminsToShop")]
    partial class AddAdminsToShop
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategoryShop", b =>
                {
                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ShopId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryShop");

                    b.HasData(
                        new
                        {
                            ShopId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            ShopId = 2,
                            CategoryId = 2
                        },
                        new
                        {
                            ShopId = 3,
                            CategoryId = 3
                        });
                });

            modelBuilder.Entity("CustomerOffer", b =>
                {
                    b.Property<int>("OffersId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("OffersId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("CustomerOffer");
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Baby"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Clothes"
                        });
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Promocode")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.Property<byte>("Stars")
                        .HasColumnType("tinyint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                    b.Property<string>("Site")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ_Shop_Name")
                        .IsUnique();

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                            Name = "Electron Plus",
                            Site = "https://eee-plus.com.ua"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                            Name = "Baby boom",
                            Site = "https://b-a-b-y-boom.com.ua"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                            Name = "Zebra",
                            Site = "https://zebrrra.biz.ua"
                        });
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Phone" }, "UQ_User_Phone")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.Customer", b =>
                {
                    b.HasBaseType("Promocodes.Data.Core.Entities.User");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Phone = "+380631111111",
                            Role = 1,
                            UserName = "alex"
                        },
                        new
                        {
                            Id = 2,
                            Phone = "+380632222222",
                            Role = 1,
                            UserName = "serg"
                        },
                        new
                        {
                            Id = 3,
                            Phone = "+380633333333",
                            Role = 1,
                            UserName = "jess"
                        },
                        new
                        {
                            Id = 4,
                            Phone = "+380634444444",
                            Role = 1,
                            UserName = "qwerty"
                        });
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.ShopAdmin", b =>
                {
                    b.HasBaseType("Promocodes.Data.Core.Entities.User");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.HasIndex("ShopId");

                    b.ToTable("ShopAdmins");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            Phone = "+30632526897",
                            Role = 0,
                            UserName = "Andrew Admin",
                            ShopId = 1
                        },
                        new
                        {
                            Id = 7,
                            Phone = "+30632526899",
                            Role = 0,
                            UserName = "Ben Admin",
                            ShopId = 1
                        },
                        new
                        {
                            Id = 8,
                            Phone = "+30632526890",
                            Role = 0,
                            UserName = "Alicia Admin",
                            ShopId = 1
                        });
                });

            modelBuilder.Entity("CategoryShop", b =>
                {
                    b.HasOne("Promocodes.Data.Core.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Promocodes.Data.Core.Entities.Shop", null)
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerOffer", b =>
                {
                    b.HasOne("Promocodes.Data.Core.Entities.Offer", null)
                        .WithMany()
                        .HasForeignKey("OffersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Promocodes.Data.Core.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.Offer", b =>
                {
                    b.HasOne("Promocodes.Data.Core.Entities.Shop", "Shop")
                        .WithMany("Offers")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.Review", b =>
                {
                    b.HasOne("Promocodes.Data.Core.Entities.Shop", "Shop")
                        .WithMany("Reviews")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Promocodes.Data.Core.Entities.Customer", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");

                    b.Navigation("Shop");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.Customer", b =>
                {
                    b.HasOne("Promocodes.Data.Core.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Promocodes.Data.Core.Entities.Customer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.ShopAdmin", b =>
                {
                    b.HasOne("Promocodes.Data.Core.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("Promocodes.Data.Core.Entities.ShopAdmin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Promocodes.Data.Core.Entities.Shop", "Shop")
                        .WithMany("Admins")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.Shop", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Offers");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Promocodes.Data.Core.Entities.Customer", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
