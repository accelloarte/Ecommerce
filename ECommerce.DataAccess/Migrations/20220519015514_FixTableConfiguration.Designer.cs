// <auto-generated />
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
    [Migration("20220519015514_FixTableConfiguration")]
    partial class FixTableConfiguration
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

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "lorem ipsum",
                            Name = "Ropa de Dama"
                        },
                        new
                        {
                            Id = 2,
                            Description = "lorem ipsum",
                            Name = "Ropa de Varon"
                        },
                        new
                        {
                            Id = 3,
                            Description = "lorem ipsum",
                            Name = "Ropa de Bebe"
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

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1989, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 2,
                            DocumentNumber = "10131",
                            Email = "customer0001@gmail.com",
                            FirstName = "Customer N°1",
                            LastName = "lorem ipsum 0"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1986, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 2,
                            DocumentNumber = "1795",
                            Email = "customer0002@gmail.com",
                            FirstName = "Customer N°2",
                            LastName = "lorem ipsum 3"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1993, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 3,
                            DocumentNumber = "5732",
                            Email = "customer0003@gmail.com",
                            FirstName = "Customer N°3",
                            LastName = "lorem ipsum 6"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1986, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 3,
                            DocumentNumber = "40631",
                            Email = "customer0004@gmail.com",
                            FirstName = "Customer N°4",
                            LastName = "lorem ipsum 9"
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1984, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 1,
                            DocumentNumber = "18282",
                            Email = "customer0005@gmail.com",
                            FirstName = "Customer N°5",
                            LastName = "lorem ipsum 12"
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1998, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 3,
                            DocumentNumber = "21071",
                            Email = "customer0006@gmail.com",
                            FirstName = "Customer N°6",
                            LastName = "lorem ipsum 15"
                        },
                        new
                        {
                            Id = 7,
                            BirthDate = new DateTime(1998, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 0,
                            DocumentNumber = "34140",
                            Email = "customer0007@gmail.com",
                            FirstName = "Customer N°7",
                            LastName = "lorem ipsum 18"
                        },
                        new
                        {
                            Id = 8,
                            BirthDate = new DateTime(1995, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 3,
                            DocumentNumber = "11315",
                            Email = "customer0008@gmail.com",
                            FirstName = "Customer N°8",
                            LastName = "lorem ipsum 21"
                        },
                        new
                        {
                            Id = 9,
                            BirthDate = new DateTime(1987, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 1,
                            DocumentNumber = "41691",
                            Email = "customer0009@gmail.com",
                            FirstName = "Customer N°9",
                            LastName = "lorem ipsum 24"
                        },
                        new
                        {
                            Id = 10,
                            BirthDate = new DateTime(1991, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Dependants = 0,
                            DocumentNumber = "21404",
                            Email = "customer0010@gmail.com",
                            FirstName = "Customer N°10",
                            LastName = "lorem ipsum 27"
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProductUrl")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

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
                            UnitPrice = 20m
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CategoryId = 1,
                            Description = "lorem ipsum",
                            Name = "Producto 2",
                            UnitPrice = 50m
                        });
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
#pragma warning restore 612, 618
        }
    }
}
