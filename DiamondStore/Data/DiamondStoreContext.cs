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

    public virtual DbSet<TblMaterialCategory> TblMaterialCategories { get; set; }

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
            entity.HasKey(e => e.AccountId).HasName("PK__Tbl_Acco__349DA5862A221B90");

            entity.ToTable("Tbl_Account");

            entity.HasIndex(e => e.Username, "UQ__Tbl_Acco__536C85E4E312153F").IsUnique();

            entity.Property(e => e.AccountId)
                .HasMaxLength(8)
                .HasColumnName("AccountID");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Tbl_Cust__A4AE64B8DE9A3415");

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
                .HasConstraintName("FK__Tbl_Custo__Accou__32E0915F");
        });

        modelBuilder.Entity<TblDiamondGradingReport>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Tbl_Diam__D5BD48E57E9D435C");

            entity.ToTable("Tbl_DiamondGradingReport");

            entity.HasIndex(e => e.GemId, "UQ__Tbl_Diam__F101D5A1927DFDAF").IsUnique();

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
                .HasConstraintName("FK__Tbl_Diamo__GemID__4E88ABD4");
        });

        modelBuilder.Entity<TblGemPriceList>(entity =>
        {
            entity.HasKey(e => e.GemId).HasName("PK__Tbl_GemP__F101D5A086FE1065");

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

        modelBuilder.Entity<TblMaterialCategory>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__Tbl_Mate__C506131708CC50C0");

            entity.ToTable("Tbl_MaterialCategory");

            entity.Property(e => e.MaterialId)
                .HasMaxLength(8)
                .HasColumnName("MaterialID");
            entity.Property(e => e.MaterialName).HasMaxLength(100);
        });

        modelBuilder.Entity<TblMaterialPriceList>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_MaterialPriceList");

            entity.Property(e => e.EffDate).HasColumnType("datetime");
            entity.Property(e => e.MaterialId)
                .HasMaxLength(8)
                .HasColumnName("MaterialID");

            entity.HasOne(d => d.Material).WithMany()
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Mater__Mater__25869641");
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
            entity.HasKey(e => e.OrderId).HasName("PK__Tbl_Orde__C3905BAF5200E04F");

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
                .HasConstraintName("FK__Tbl_Order__Custo__3F466844");

            entity.HasOne(d => d.Staff).WithMany(p => p.TblOrders)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Order__Staff__403A8C7D");
        });

        modelBuilder.Entity<TblOrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__Tbl_Orde__D3B9D30CAD99CDCD");

            entity.ToTable("Tbl_OrderDetail");

            entity.Property(e => e.OrderDetailId)
                .HasMaxLength(8)
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(8)
                .HasColumnName("OrderID");
            entity.Property(e => e.ProductId)
                .HasMaxLength(8)
                .HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.TblOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Tbl_Order__Order__4316F928");

            entity.HasOne(d => d.Product).WithMany(p => p.TblOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Order__Produ__440B1D61");
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
                .HasConstraintName("FK__Tbl_Payme__Custo__46E78A0C");

            entity.HasOne(d => d.Order).WithMany()
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Payme__Order__45F365D3");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Tbl_Prod__B40CC6EDDE6E10E1");

            entity.ToTable("Tbl_Product");

            entity.HasIndex(e => e.GemId, "UQ__Tbl_Prod__F101D5A11424433A").IsUnique();

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
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.ProductName).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Produ__Categ__37A5467C");

            entity.HasOne(d => d.Gem).WithOne(p => p.TblProduct)
                .HasForeignKey<TblProduct>(d => d.GemId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Tbl_Produ__GemID__38996AB5");
        });

        modelBuilder.Entity<TblProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Tbl_Prod__19093A2B071A51C1");

            entity.ToTable("Tbl_ProductCategory");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(8)
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<TblProductMaterial>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.MaterialId }).HasName("PK__Tbl_Prod__D85CA7DCB9A2ECFF");

            entity.ToTable("Tbl_ProductMaterial");

            entity.Property(e => e.ProductId)
                .HasMaxLength(8)
                .HasColumnName("ProductID");
            entity.Property(e => e.MaterialId)
                .HasMaxLength(8)
                .HasColumnName("MaterialID");

            entity.HasOne(d => d.Material).WithMany(p => p.TblProductMaterials)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK__Tbl_Produ__Mater__3C69FB99");

            entity.HasOne(d => d.Product).WithMany(p => p.TblProductMaterials)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Tbl_Produ__Produ__3B75D760");
        });

        modelBuilder.Entity<TblStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Tbl_Staf__96D4AAF7AF3E9E3F");

            entity.ToTable("Tbl_Staff");

            entity.HasIndex(e => e.AccountId, "UQ__Tbl_Staf__349DA587EC9A0A0B").IsUnique();

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
                .HasConstraintName("FK__Tbl_Staff__Accou__300424B4");
        });

        modelBuilder.Entity<TblWarranty>(entity =>
        {
            entity.HasKey(e => e.WarrantyId).HasName("PK__Tbl_Warr__2ED318F33DC113EC");

            entity.ToTable("Tbl_Warranty");

            entity.HasIndex(e => e.OrderDetailId, "UQ__Tbl_Warr__D3B9D30DDB04BBCD").IsUnique();

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
                .HasConstraintName("FK__Tbl_Warra__Order__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
