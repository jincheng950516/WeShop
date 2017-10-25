namespace Shop.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WeShop : DbContext
    {
        public WeShop()
            : base("name=WeShop")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Notice> Notice { get; set; }
        public virtual DbSet<OrderBillChi> OrderBillChi { get; set; }
        public virtual DbSet<OrderBillFath> OrderBillFath { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProPhoto> ProPhoto { get; set; }
        public virtual DbSet<ProReview> ProReview { get; set; }
        public virtual DbSet<ProSort> ProSort { get; set; }
        public virtual DbSet<ProTag> ProTag { get; set; }
        public virtual DbSet<ShopCart> ShopCart { get; set; }
        public virtual DbSet<Sort> Sort { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Customer>()
                .HasOptional(e => e.OrderBillFath)
                .WithRequired(e => e.Customer);

            modelBuilder.Entity<Customer>()
                .HasOptional(e => e.ProReview)
                .WithRequired(e => e.Customer);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ShopCart)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Cusid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.ShopCart1)
                .WithRequired(e => e.Customer1)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderBillChi>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderBillFath>()
                .Property(e => e.totalprice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<OrderBillFath>()
                .HasMany(e => e.OrderBillChi)
                .WithRequired(e => e.OrderBillFath)
                .HasForeignKey(e => e.Code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderBillFath>()
                .HasMany(e => e.OrderBillChi1)
                .WithRequired(e => e.OrderBillFath1)
                .HasForeignKey(e => e.procode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment>()
                .HasOptional(e => e.OrderBillFath)
                .WithRequired(e => e.Payment);

            modelBuilder.Entity<Product>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderBillChi)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Code)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderBillChi1)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.procode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.Product1)
                .WithRequired(e => e.Product2);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProPhoto)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.No)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProPhoto1)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasOptional(e => e.ProReview)
                .WithRequired(e => e.Product);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProSort)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.SortCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProTag)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProTag1)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.TagId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ShopCart)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.Cusid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ShopCart1)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Stock)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.prode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Stock1)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.billcode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sort>()
                .HasMany(e => e.ProSort)
                .WithRequired(e => e.Sort)
                .HasForeignKey(e => e.SortCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sort>()
                .HasMany(e => e.ProSort1)
                .WithRequired(e => e.Sort1)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sort>()
                .HasMany(e => e.ProSort2)
                .WithRequired(e => e.Sort2)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.ProTag)
                .WithRequired(e => e.Tag)
                .HasForeignKey(e => e.ProCode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasMany(e => e.ProTag1)
                .WithRequired(e => e.Tag1)
                .HasForeignKey(e => e.TagId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .HasOptional(e => e.Tag1)
                .WithRequired(e => e.Tag2);
        }
    }
}
