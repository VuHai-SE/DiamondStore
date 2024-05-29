using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DiamondStore.Data;

public partial class DiamondStoreContext : DbContext
{
    public DiamondStoreContext()
    {
    }

    public DiamondStoreContext(DbContextOptions<DiamondStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblDiamondGradingReport> TblDiamondGradingReports { get; set; }

    public virtual DbSet<TblGemPriceList> TblGemPriceLists { get; set; }

    public virtual DbSet<TblMaterialPriceList> TblMaterialPriceLists { get; set; }

    public virtual DbSet<TblMembership> TblMemberships { get; set; }

    public virtual DbSet<TblOrder> TblOrders { get; set; }

    public virtual DbSet<TblOrderDetail> TblOrderDetails { get; set; }

    public virtual DbSet<TblPayment> TblPayments { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblProductCategory> TblProductCategories { get; set; }

    public virtual DbSet<TblProductMaterial> TblProductMaterials { get; set; }

    public virtual DbSet<TblStaff> TblStaffs { get; set; }

    public virtual DbSet<TblWarranty> TblWarranties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Tbl_Acco__349DA586D65CA5BC");

            entity.ToTable("Tbl_Account");

            entity.HasIndex(e => e.Username, "UQ__Tbl_Acco__536C85E460F9368E").IsUnique();

            entity.Property(e => e.AccountId)
                .HasMaxLength(8)
                .HasColumnName("AccountID");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Tbl_Cust__A4AE64B81AD6489A");

            entity.ToTable("Tbl_Customer");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(8)
                .HasColumnName("CustomerID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(8)
                .HasColumnName("AccountID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);

            entity.HasOne(d => d.Account).WithMany(p => p.TblCustomers)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Tbl_Custo__Accou__30F848ED");
        });

        modelBuilder.Entity<TblDiamondGradingReport>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Tbl_Diam__D5BD48E5A36B7021");

            entity.ToTable("Tbl_DiamondGradingReport");

            entity.HasIndex(e => e.GemId, "UQ__Tbl_Diam__F101D5A1E5C37297").IsUnique();

            entity.Property(e => e.ReportId)
                .HasMaxLength(8)
                .HasColumnName("ReportID");
            entity.Property(e => e.GemId)
                .HasMaxLength(8)
                .HasColumnName("GemID");
            entity.Property(e => e.GenerateDate).HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(255);

            entity.HasOne(d => d.Gem).WithOne(p => p.TblDiamondGradingReport)
                .HasForeignKey<TblDiamondGradingReport>(d => d.GemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Diamo__GemID__5070F446");
        });

        modelBuilder.Entity<TblGemPriceList>(entity =>
        {
            entity.HasKey(e => e.GemId).HasName("PK__Tbl_GemP__F101D5A027FF1C31");

            entity.ToTable("Tbl_GemPriceList");

            entity.Property(e => e.GemId)
                .HasMaxLength(8)
                .HasColumnName("GemID");
            entity.Property(e => e.Clarity).HasMaxLength(50);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Cut).HasMaxLength(50);
            entity.Property(e => e.EffDate).HasColumnType("datetime");
            entity.Property(e => e.Fluorescence).HasMaxLength(50);
            entity.Property(e => e.GemCode).HasMaxLength(50);
            entity.Property(e => e.Origin).HasMaxLength(100);
            entity.Property(e => e.Polish).HasMaxLength(50);
            entity.Property(e => e.Shape).HasMaxLength(50);
            entity.Property(e => e.Symmetry).HasMaxLength(50);
        });

        modelBuilder.Entity<TblMaterialPriceList>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__Tbl_Mate__C50613174E5E254C");

            entity.ToTable("Tbl_MaterialPriceList");

            entity.Property(e => e.MaterialId)
                .HasMaxLength(8)
                .HasColumnName("MaterialID");
            entity.Property(e => e.EffDate).HasColumnType("datetime");
            entity.Property(e => e.MaterialName).HasMaxLength(100);
        });

        modelBuilder.Entity<TblMembership>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_Membership");

            entity.Property(e => e.Ranking).HasMaxLength(50);
        });

        modelBuilder.Entity<TblOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Tbl_Orde__C3905BAFDCF12355");

            entity.ToTable("Tbl_Order");

            entity.Property(e => e.OrderId)
                .HasMaxLength(8)
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(8)
                .HasColumnName("CustomerID");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderStatus).HasMaxLength(50);
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.ReceiveDate).HasColumnType("datetime");
            entity.Property(e => e.ShipperId)
                .HasMaxLength(8)
                .HasColumnName("ShipperID");
            entity.Property(e => e.ShippingDate).HasColumnType("datetime");
            entity.Property(e => e.StaffId)
                .HasMaxLength(8)
                .HasColumnName("StaffID");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Tbl_Order__Custo__3D5E1FD2");

            entity.HasOne(d => d.Staff).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Order__Staff__3E52440B");
        });

        modelBuilder.Entity<TblOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__Tbl_Orde__D3B9D30C4473ADC2");

            entity.ToTable("Tbl_OrderDetail");

            entity.Property(e => e.OrderDetailId)
                .HasMaxLength(8)
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.CustomizedSize).HasMaxLength(50);
            entity.Property(e => e.OrderId)
                .HasMaxLength(8)
                .HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(8)
                .HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.TblOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Tbl_Order__Order__412EB0B6");

            entity.HasOne(d => d.Product).WithMany(p => p.TblOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Order__Produ__4222D4EF");
        });

        modelBuilder.Entity<TblPayment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_Payment");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(8)
                .HasColumnName("CustomerID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(8)
                .HasColumnName("OrderID");
            entity.Property(e => e.PayDetail).HasMaxLength(255);
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany()
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Tbl_Payme__Custo__48CFD27E");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Payme__Order__47DBAE45");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Tbl_Prod__B40CC6ED5AD448C1");

            entity.ToTable("Tbl_Product");

            entity.HasIndex(e => e.GemId, "UQ__Tbl_Prod__F101D5A12B2203B7").IsUnique();

            entity.Property(e => e.ProductId)
                .HasMaxLength(8)
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(8)
                .HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.GemId)
                .HasMaxLength(8)
                .HasColumnName("GemID");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.PriceSize).HasMaxLength(50);
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.ProductSize).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Produ__Categ__35BCFE0A");

            entity.HasOne(d => d.Gem).WithOne(p => p.TblProduct)
                .HasForeignKey<TblProduct>(d => d.GemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Produ__GemID__36B12243");
        });

        modelBuilder.Entity<TblProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Tbl_Prod__19093A2B204CE2BD");

            entity.ToTable("Tbl_ProductCategory");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(8)
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<TblProductMaterial>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.MaterialId }).HasName("PK__Tbl_Prod__D85CA7DC40BD4E39");

            entity.ToTable("Tbl_ProductMaterial");

            entity.Property(e => e.ProductId)
                .HasMaxLength(8)
                .HasColumnName("ProductID");
            entity.Property(e => e.MaterialId)
                .HasMaxLength(8)
                .HasColumnName("MaterialID");

            entity.HasOne(d => d.Material).WithMany(p => p.TblProductMaterials)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK__Tbl_Produ__Mater__3A81B327");

            entity.HasOne(d => d.Product).WithMany(p => p.TblProductMaterials)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Tbl_Produ__Produ__398D8EEE");
        });

        modelBuilder.Entity<TblStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Tbl_Staf__96D4AAF7B6532997");

            entity.ToTable("Tbl_Staff");

            entity.HasIndex(e => e.AccountId, "UQ__Tbl_Staf__349DA58779B56608").IsUnique();

            entity.Property(e => e.StaffId)
                .HasMaxLength(8)
                .HasColumnName("StaffID");
            entity.Property(e => e.AccountId)
                .HasMaxLength(8)
                .HasColumnName("AccountID");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);

            entity.HasOne(d => d.Account).WithOne(p => p.TblStaff)
                .HasForeignKey<TblStaff>(d => d.AccountId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Staff__Accou__2E1BDC42");
        });

        modelBuilder.Entity<TblWarranty>(entity =>
        {
            entity.HasKey(e => e.WarrantyId).HasName("PK__Tbl_Warr__2ED318F334EA28B0");

            entity.ToTable("Tbl_Warranty");

            entity.HasIndex(e => e.OrderDetailId, "UQ__Tbl_Warr__D3B9D30D337A2FA8").IsUnique();

            entity.Property(e => e.WarrantyId)
                .HasMaxLength(8)
                .HasColumnName("WarrantyID");
            entity.Property(e => e.OrderDetailId)
                .HasMaxLength(8)
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.WarrantyEndDate).HasColumnType("datetime");
            entity.Property(e => e.WarrantyStartDate).HasColumnType("datetime");

            entity.HasOne(d => d.OrderDetail).WithOne(p => p.TblWarranty)
                .HasForeignKey<TblWarranty>(d => d.OrderDetailId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Warra__Order__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
