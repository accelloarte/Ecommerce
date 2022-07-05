using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ECommerce.Entities.Infos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ECommerce.DataAccess
{
    public class ECommerceDbContext : IdentityDbContext<ECommerceUserIdentity>
    {
        public ECommerceDbContext()
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ECommerceDB;Trusted_Connection=True");
        //    }
        //}

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // FLUENT API (API FLUIDA)

            //modelBuilder.Entity<Category>()
            //    .Property(p => p.Name)
            //    .HasMaxLength(100);

            //modelBuilder.Entity<Product>()
            //    .Property(p => p.Name)
            //    .HasMaxLength(100);

            //modelBuilder.Entity<Product>()
            //    .Property(p => p.Description)
            //    //.IsRequired()
            //    .HasMaxLength(200);

            //modelBuilder.Entity<Product>()
            //    .Property(p => p.ProductUrl)
            //    .HasMaxLength(500)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Product>()
            //    .Property(x => x.UnitPrice)
            //    .HasColumnType("money")
            //    .HasPrecision(8, 2);

            //modelBuilder.Entity<Category>()
            //    .HasData(new List<Category>()
            //    {
            //        new Category() { Id = 1, Name = "Ropa de Dama", Description = "lorem ipsum" },
            //        new Category() { Id = 2, Name = "Ropa de Varon", Description = "lorem ipsum" },
            //        new Category() { Id = 3, Name = "Ropa de Bebe", Description = "lorem ipsum" },
            //    });

            //modelBuilder.Entity<Product>()
            //    .HasData(new List<Product>()
            //    {
            //        new Product()
            //        {
            //            Id = 1, CategoryId = 1, Active = true, Name = "Producto 1", 
            //            Description = "lorem ipsum", UnitPrice = 20
            //        },
            //        new Product()
            //        {
            //            Id = 2, CategoryId = 1, Active = true, Name = "Producto 2", 
            //            Description = "lorem ipsum", UnitPrice = 50
            //        },
            //    });

            // Agregamos la configuracion a mano, clase por clase.

            //modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            // Agregamos la configuracion de todas las clases del emsamblado.

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ReportInfo>()
                .HasNoKey();

            modelBuilder.Entity<ReportInfo>()
                .Property(p => p.TotalSale)
                .HasPrecision(11, 2);

            modelBuilder.Entity<SaleDetailInfo>()
                .HasNoKey();

            modelBuilder.Entity<SaleDetailInfo>()
                .Property(p => p.UnitPrice)
                .HasPrecision(11, 2);
            
            modelBuilder.Entity<SaleDetailInfo>()
                .Property(p => p.Quantity)
                .HasPrecision(11, 2);
            
            modelBuilder.Entity<SaleDetailInfo>()
                .Property(p => p.Total)
                .HasPrecision(11, 2);

            //modelBuilder.Ignore<ReportInfo>();
        }

        //public DbSet<Customer> Customers { get; set; }
    }
}