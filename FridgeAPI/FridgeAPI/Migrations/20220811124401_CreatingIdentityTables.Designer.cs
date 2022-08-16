﻿// <auto-generated />
using System;
using Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FridgeAPI.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20220811124401_CreatingIdentityTables")]
    partial class CreatingIdentityTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Fridge", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("name");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("owner_name");

                    b.HasKey("Id");

                    b.ToTable("fridge");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2b544aed-49ad-41f4-9372-8f2d9a9e6956"),
                            Name = "Bosch",
                            OwnerName = "Alex"
                        },
                        new
                        {
                            Id = new Guid("48691dc6-312c-48e5-bd0d-ff23c852b9b3"),
                            Name = "LG",
                            OwnerName = "Mike"
                        },
                        new
                        {
                            Id = new Guid("50e1549e-0bc1-4f8d-a21e-648738e3ecb9"),
                            Name = "VR",
                            OwnerName = "Nikita"
                        });
                });

            modelBuilder.Entity("Entities.Models.FridgeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("id");

                    b.Property<Guid>("FridgeId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("fridge_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("name");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.HasIndex("FridgeId");

                    b.ToTable("fridge_model");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d098d69c-ff78-4f2a-bf7f-c9d343898963"),
                            FridgeId = new Guid("2b544aed-49ad-41f4-9372-8f2d9a9e6956"),
                            Name = "KGV39XW2AR",
                            Year = 2020
                        },
                        new
                        {
                            Id = new Guid("14ac0bdd-7e08-4d49-a439-6c4634529d74"),
                            FridgeId = new Guid("48691dc6-312c-48e5-bd0d-ff23c852b9b3"),
                            Name = "GA-B379SLUL",
                            Year = 2018
                        },
                        new
                        {
                            Id = new Guid("6a5845af-1c8b-4060-9f1c-70018a63cb09"),
                            FridgeId = new Guid("50e1549e-0bc1-4f8d-a21e-648738e3ecb9"),
                            Name = "FR-102V",
                            Year = 2017
                        });
                });

            modelBuilder.Entity("Entities.Models.FridgeProducts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("id");

                    b.Property<Guid>("FridgeId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("fridge_id");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantuty")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("FridgeId");

                    b.HasIndex("ProductId");

                    b.ToTable("fridge_products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7ad906f6-5740-4bb8-a7b3-d70134cec431"),
                            FridgeId = new Guid("2b544aed-49ad-41f4-9372-8f2d9a9e6956"),
                            ProductId = new Guid("7ac83035-17e7-4a9d-89ef-a7e2b14e931b"),
                            Quantuty = 2
                        },
                        new
                        {
                            Id = new Guid("d6cb8731-b5a4-4ca6-9895-cab735417d93"),
                            FridgeId = new Guid("48691dc6-312c-48e5-bd0d-ff23c852b9b3"),
                            ProductId = new Guid("5c6d012b-dc74-4580-9716-141de40af83d"),
                            Quantuty = 3
                        },
                        new
                        {
                            Id = new Guid("23ae3b61-067f-4c2a-88cb-11b6098712de"),
                            FridgeId = new Guid("48691dc6-312c-48e5-bd0d-ff23c852b9b3"),
                            ProductId = new Guid("6f377e69-b477-463a-a874-763660787941"),
                            Quantuty = 1
                        },
                        new
                        {
                            Id = new Guid("e47f4bc8-60d7-4e59-b4c3-af50b7f732dc"),
                            FridgeId = new Guid("50e1549e-0bc1-4f8d-a21e-648738e3ecb9"),
                            ProductId = new Guid("394c70b6-53c7-4b0a-bf98-a1bbd7c3c5c5"),
                            Quantuty = 2
                        },
                        new
                        {
                            Id = new Guid("bd22f93c-252c-4cd9-b23e-6c7345804f9c"),
                            FridgeId = new Guid("50e1549e-0bc1-4f8d-a21e-648738e3ecb9"),
                            ProductId = new Guid("3080f5cf-523e-405c-80e4-75d468a1a94e"),
                            Quantuty = 0
                        });
                });

            modelBuilder.Entity("Entities.Models.Products", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER")
                        .HasColumnName("id");

                    b.Property<int>("DefaultQuantity")
                        .HasColumnType("int")
                        .HasColumnName("default_quantity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7ac83035-17e7-4a9d-89ef-a7e2b14e931b"),
                            DefaultQuantity = 3,
                            Name = "Apple"
                        },
                        new
                        {
                            Id = new Guid("5c6d012b-dc74-4580-9716-141de40af83d"),
                            DefaultQuantity = 1,
                            Name = "Water"
                        },
                        new
                        {
                            Id = new Guid("6f377e69-b477-463a-a874-763660787941"),
                            DefaultQuantity = 10,
                            Name = "Eggs"
                        },
                        new
                        {
                            Id = new Guid("394c70b6-53c7-4b0a-bf98-a1bbd7c3c5c5"),
                            DefaultQuantity = 1,
                            Name = "Milk"
                        },
                        new
                        {
                            Id = new Guid("3080f5cf-523e-405c-80e4-75d468a1a94e"),
                            DefaultQuantity = 2,
                            Name = "Orange"
                        });
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Entities.Models.FridgeModel", b =>
                {
                    b.HasOne("Entities.Models.Fridge", "Fridge")
                        .WithMany("FridgeModels")
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");
                });

            modelBuilder.Entity("Entities.Models.FridgeProducts", b =>
                {
                    b.HasOne("Entities.Models.Fridge", "Fridge")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("FridgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Products", "Products")
                        .WithMany("FridgeProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fridge");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Entities.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Models.Fridge", b =>
                {
                    b.Navigation("FridgeModels");

                    b.Navigation("FridgeProducts");
                });

            modelBuilder.Entity("Entities.Models.Products", b =>
                {
                    b.Navigation("FridgeProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
