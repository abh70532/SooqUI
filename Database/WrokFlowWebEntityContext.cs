using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WrokFlowWeb.Database
{
    public partial class WrokFlowWebEntityContext : DbContext
    {
        public WrokFlowWebEntityContext()
        {
        }

        public WrokFlowWebEntityContext(DbContextOptions<WrokFlowWebEntityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApprovalFormMaster> ApprovalFormMaster { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CategoryMaster> CategoryMaster { get; set; }
        public virtual DbSet<ModuleMaster> ModuleMaster { get; set; }
        public virtual DbSet<RequestTypeMaster> RequestTypeMaster { get; set; }
        public virtual DbSet<RoleApprovalMaster> RoleApprovalMaster { get; set; }
        public virtual DbSet<SuplierTypeRequestMaster> SuplierTypeRequestMaster { get; set; }
        public virtual DbSet<SupplierRegistrationInternalQuestion> SupplierRegistrationInternalQuestion { get; set; }
        public virtual DbSet<SupplierRequest> SupplierRequest { get; set; }
        public virtual DbSet<SupplierRequestApprovalLog> SupplierRequestApprovalLog { get; set; }
        public virtual DbSet<SupplierRequestCategoryMapping> SupplierRequestCategoryMapping { get; set; }
        public virtual DbSet<TabMaster> TabMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=WrokFlowWeb;User Id=sa; Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApprovalFormMaster>(entity =>
            {
                entity.Property(e => e.ApprovalFormMasterName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.CostCenter).HasMaxLength(100);

                entity.Property(e => e.Department).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.SupplierRequest)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.SupplierRequestId)
                    .HasConstraintName("FK_AspNetUsers_SupplierRequest");
            });

            modelBuilder.Entity<CategoryMaster>(entity =>
            {
                entity.Property(e => e.CategoryMasterId).ValueGeneratedOnAdd();

                entity.Property(e => e.Category).HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ModuleMaster>(entity =>
            {
                entity.HasKey(e => e.ModuleId)
                    .HasName("PK_Module");

                entity.Property(e => e.ModuleId).ValueGeneratedOnAdd();

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<RequestTypeMaster>(entity =>
            {
                entity.Property(e => e.RequestTypeMasterId).ValueGeneratedOnAdd();

                entity.Property(e => e.RequestType).HasMaxLength(100);
            });

            modelBuilder.Entity<RoleApprovalMaster>(entity =>
            {
                entity.Property(e => e.RoleApprovalMasterId).ValueGeneratedOnAdd();

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.RoleApprovalMaster)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleApprovalMaster_Module");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleApprovalMaster)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleApprovalMaster_AspNetRoles");
            });

            modelBuilder.Entity<SuplierTypeRequestMaster>(entity =>
            {
                entity.HasKey(e => e.SuplierTypeRequestId)
                    .HasName("PK_SuplierTypeRequest");

                entity.Property(e => e.SuplierTypeRequestId).ValueGeneratedOnAdd();

                entity.Property(e => e.SuplierTypeRequest).HasMaxLength(100);
            });

            modelBuilder.Entity<SupplierRegistrationInternalQuestion>(entity =>
            {
                entity.Property(e => e.AccountGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ActualQmsystem)
                    .HasColumnName("ActualQMSystem")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BlockForCompanyCodeAlba)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BlockForPurchasingOrganisation)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BlockForQualityReasons)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CashMangementGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CheckDoubleInvoice)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ClerkAbbrevation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Industry)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderCurreny)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PurchasingOrganisation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReconsiliationAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SearchTerm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SetIncoterm)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TrainStation)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SupplierRequest>(entity =>
            {
                entity.Property(e => e.Address1).HasMaxLength(200);

                entity.Property(e => e.Address2).HasMaxLength(200);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.ContactPhone).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.CreatedBy).HasMaxLength(450);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Department).HasMaxLength(100);

                entity.Property(e => e.EmailId).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsEditable)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PostalCode).HasMaxLength(50);

                entity.Property(e => e.RequesterName).HasMaxLength(100);

                entity.Property(e => e.Street).HasMaxLength(100);

                entity.Property(e => e.SupplierName).HasMaxLength(100);

                entity.Property(e => e.SupplierRequestApprovalId).HasColumnName("SupplierRequestApprovalID");

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.RequestTypeMaster)
                    .WithMany(p => p.SupplierRequest)
                    .HasForeignKey(d => d.RequestTypeMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierRequest_RequestTypeMaster");

                entity.HasOne(d => d.SuplierTypeRequest)
                    .WithMany(p => p.SupplierRequest)
                    .HasForeignKey(d => d.SuplierTypeRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierRequest_SuplierTypeRequestMaster");
            });

            modelBuilder.Entity<SupplierRequestApprovalLog>(entity =>
            {
                entity.HasKey(e => e.SupplierRequestApprovalId);

                entity.Property(e => e.SupplierRequestApprovalId).HasColumnName("SupplierRequestApprovalID");

                entity.Property(e => e.ApprovalComments).HasMaxLength(450);

                entity.Property(e => e.ApprovedBy).HasMaxLength(450);

                entity.Property(e => e.ApprovedOn).HasColumnType("datetime");

                entity.HasOne(d => d.RoleApprovalMaster)
                    .WithMany(p => p.SupplierRequestApprovalLog)
                    .HasForeignKey(d => d.RoleApprovalMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierRequestApprovalLog_RoleApprovalMaster");

                entity.HasOne(d => d.SupplierRequest)
                    .WithMany(p => p.SupplierRequestApprovalLog)
                    .HasForeignKey(d => d.SupplierRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierRequestApprovalLog_SupplierRequestApprovalLog");
            });

            modelBuilder.Entity<SupplierRequestCategoryMapping>(entity =>
            {
                entity.Property(e => e.SupplierRequestCategoryMappingId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.CategoryMaster)
                    .WithMany(p => p.SupplierRequestCategoryMapping)
                    .HasForeignKey(d => d.CategoryMasterId)
                    .HasConstraintName("FK_SupplierRequestCategoryMapping_CategoryMaster");

                entity.HasOne(d => d.SupplierRequest)
                    .WithMany(p => p.SupplierRequestCategoryMapping)
                    .HasForeignKey(d => d.SupplierRequestId)
                    .HasConstraintName("FK_SupplierRequestCategoryMapping_SupplierRequest");
            });

            modelBuilder.Entity<TabMaster>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TabMasterName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
