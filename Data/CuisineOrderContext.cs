using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CuisineOrdersAPI.Models;

namespace CuisineOrdersAPI.Data
{
    public partial class CuisineOrderContext : DbContext
    {
        public CuisineOrderContext()
        {
        }

        public CuisineOrderContext(DbContextOptions<CuisineOrderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OnlineOrderHeader> OnlineOrderHeader { get; set; }
        public virtual DbSet<OnlineOrderLines> OnlineOrderLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=41.185.30.246; initial catalog=CUFABMWPJune2014; User ID=Jean; Password=Genie77;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OnlineOrderHeader>(entity =>
            {
                entity.HasKey(e => e.OnlineOrderId);

                entity.Property(e => e.OnlineOrderId).HasColumnName("OnlineOrderID");

                entity.Property(e => e.AppOrderId).HasColumnName("AppOrderID");

                entity.Property(e => e.CartTax).HasColumnType("money");

                entity.Property(e => e.CartTotal).HasColumnType("money");

                entity.Property(e => e.CreatedVia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CuisineOrderStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Not Processed')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerEmployeeNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerFirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerNotes)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.DatePaid).HasColumnType("datetime");

                entity.Property(e => e.DiscountTax).HasColumnType("money");

                entity.Property(e => e.DiscountTotal).HasColumnType("money");

                entity.Property(e => e.OrderKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderLinesSaved).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderUrl)
                    .HasColumnName("OrderURL")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OnlineOrderLines>(entity =>
            {
                entity.HasKey(e => e.OnlineOrderLineId);

                //entity.Property(e => e.OnlineOrderLineId)
                //    .HasColumnName("OnlineOrderLineID")
                //    .ValueGeneratedNever();

                entity.Property(e => e.OnlineOrderLineId)
                    .HasColumnName("OnlineOrderLineID");

                entity.Property(e => e.AppOrderId).HasColumnName("AppOrderID");

                entity.Property(e => e.AppOrderLineId).HasColumnName("AppOrderLineID");

                entity.Property(e => e.Category)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OnlineOrderHeaderId).HasColumnName("OnlineOrderHeaderID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("SKU")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.Property(e => e.SubTotalTax).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
