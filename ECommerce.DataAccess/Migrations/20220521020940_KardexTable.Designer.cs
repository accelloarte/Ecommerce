﻿// <auto-generated />
using System;
using ECommerce.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    [DbContext(typeof(ECommerceDbContext))]
    [Migration("20220521020940_KardexTable")]
    partial class KardexTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ECommerce.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "lorem ipsum",
                            Name = "Ropa de Dama",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            Description = "lorem ipsum",
                            Name = "Ropa de Varon",
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            Description = "lorem ipsum",
                            Name = "Ropa de Bebe",
                            Status = true
                        });
                });

            modelBuilder.Entity("ECommerce.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATE");

                    b.Property<int?>("Dependants")
                        .HasColumnType("int");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DocumentNumber")
                        .IsUnique();

                    b.ToTable("Customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1984, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 1,
                            DocumentNumber = "6625",
                            Email = "customer0001@gmail.com",
                            FirstName = "Customer N°1",
                            LastName = "lorem ipsum 0",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1990, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 1,
                            DocumentNumber = "56744",
                            Email = "customer0002@gmail.com",
                            FirstName = "Customer N°2",
                            LastName = "lorem ipsum 3",
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1995, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 3,
                            DocumentNumber = "9792",
                            Email = "customer0003@gmail.com",
                            FirstName = "Customer N°3",
                            LastName = "lorem ipsum 6",
                            Status = true
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1986, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 1,
                            DocumentNumber = "18437",
                            Email = "customer0004@gmail.com",
                            FirstName = "Customer N°4",
                            LastName = "lorem ipsum 9",
                            Status = true
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1980, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 2,
                            DocumentNumber = "28320",
                            Email = "customer0005@gmail.com",
                            FirstName = "Customer N°5",
                            LastName = "lorem ipsum 12",
                            Status = true
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1989, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 3,
                            DocumentNumber = "11565",
                            Email = "customer0006@gmail.com",
                            FirstName = "Customer N°6",
                            LastName = "lorem ipsum 15",
                            Status = true
                        },
                        new
                        {
                            Id = 7,
                            BirthDate = new DateTime(1981, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 3,
                            DocumentNumber = "36129",
                            Email = "customer0007@gmail.com",
                            FirstName = "Customer N°7",
                            LastName = "lorem ipsum 18",
                            Status = true
                        },
                        new
                        {
                            Id = 8,
                            BirthDate = new DateTime(1980, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 3,
                            DocumentNumber = "497",
                            Email = "customer0008@gmail.com",
                            FirstName = "Customer N°8",
                            LastName = "lorem ipsum 21",
                            Status = true
                        },
                        new
                        {
                            Id = 9,
                            BirthDate = new DateTime(1987, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 0,
                            DocumentNumber = "43795",
                            Email = "customer0009@gmail.com",
                            FirstName = "Customer N°9",
                            LastName = "lorem ipsum 24",
                            Status = true
                        },
                        new
                        {
                            Id = 10,
                            BirthDate = new DateTime(1996, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 1,
                            DocumentNumber = "51830",
                            Email = "customer0010@gmail.com",
                            FirstName = "Customer N°10",
                            LastName = "lorem ipsum 27",
                            Status = true
                        });
                });

            modelBuilder.Entity("ECommerce.Entities.Kardex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MovementType")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ocurred")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Kardex", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MovementType = 2,
                            Ocurred = new DateTime(2022, 5, 20, 21, 9, 39, 786, DateTimeKind.Local).AddTicks(8843),
                            ProductId = 3,
                            Quantity = 200L,
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            MovementType = 2,
                            Ocurred = new DateTime(2022, 5, 20, 21, 9, 39, 786, DateTimeKind.Local).AddTicks(8855),
                            ProductId = 4,
                            Quantity = 100L,
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            MovementType = 2,
                            Ocurred = new DateTime(2022, 5, 20, 21, 9, 39, 786, DateTimeKind.Local).AddTicks(8856),
                            ProductId = 5,
                            Quantity = 10L,
                            Status = true
                        },
                        new
                        {
                            Id = 4,
                            MovementType = 2,
                            Ocurred = new DateTime(2022, 5, 20, 21, 9, 39, 786, DateTimeKind.Local).AddTicks(8856),
                            ProductId = 6,
                            Quantity = 2L,
                            Status = true
                        });
                });

            modelBuilder.Entity("ECommerce.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductUrl")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(8, 2)
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CategoryId = 1,
                            Description = "lorem ipsum",
                            Name = "Producto 1",
                            Status = true,
                            UnitPrice = 20m
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CategoryId = 1,
                            Description = "lorem ipsum",
                            Name = "Producto 2",
                            Status = true,
                            UnitPrice = 50m
                        });
                });

            modelBuilder.Entity("ECommerce.Entities.Sale", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvoiceId"), 1L, 1);

                    b.Property<int>("CustomerFk")
                        .HasColumnType("int");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValueSql("getdate()");

                    b.Property<decimal>("TotalSale")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CustomerFk")
                        .IsUnique();

                    b.HasIndex("InvoiceNumber")
                        .IsUnique();

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("ECommerce.Entities.SaleDetail", b =>
                {
                    b.Property<int>("SaleDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleDetailId"), 1L, 1);

                    b.Property<int>("ItemNumber")
                        .HasColumnType("int");

                    b.Property<int>("ProductIdentifier")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("SaleIdFk")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalSale")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("SaleDetailId");

                    b.HasIndex("ProductIdentifier");

                    b.HasIndex("SaleIdFk");

                    b.ToTable("SaleDetail");
                });

            modelBuilder.Entity("ECommerce.Entities.Kardex", b =>
                {
                    b.HasOne("ECommerce.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ECommerce.Entities.Product", b =>
                {
                    b.HasOne("ECommerce.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ECommerce.Entities.Sale", b =>
                {
                    b.HasOne("ECommerce.Entities.Customer", "Customer")
                        .WithOne()
                        .HasForeignKey("ECommerce.Entities.Sale", "CustomerFk")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ECommerce.Entities.SaleDetail", b =>
                {
                    b.HasOne("ECommerce.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductIdentifier")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ECommerce.Entities.Sale", "Sale")
                        .WithMany()
                        .HasForeignKey("SaleIdFk")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });
#pragma warning restore 612, 618
        }
    }
}