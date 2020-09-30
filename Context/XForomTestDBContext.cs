using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using XforumTest.Models;

namespace XforumTest.Context
{
    public partial class XForomTestDBContext : DbContext
    {
        public XForomTestDBContext()
        {
        }

        public XForomTestDBContext(DbContextOptions<XForomTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItems> CartItems { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Coupons> Coupons { get; set; }
        public virtual DbSet<Forum> Forum { get; set; }
        public virtual DbSet<ForumMember> ForumMember { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductImgs> ProductImgs { get; set; }
        public virtual DbSet<ProductTags> ProductTags { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Thread> Thread { get; set; }
        public virtual DbSet<WishList> WishList { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=xforumtest.database.windows.net,1433;Database=XForomTestDB;User=test;Password=!a1234567;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId).ValueGeneratedNever();

                entity.Property(e => e.UserId).HasMaxLength(128);
            });

            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItmes_Cart");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CartItmes_Product1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Coupons>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CouponCode).HasMaxLength(50);

                entity.Property(e => e.CouponName).HasMaxLength(50);

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Forum>(entity =>
            {
                entity.Property(e => e.ForumId).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Img).HasMaxLength(50);

                entity.HasOne(d => d.Moderator)
                    .WithMany(p => p.Forum)
                    .HasForeignKey(d => d.ModeratorId)
                    .HasConstraintName("FK_Forum_ForumMember");
            });

            modelBuilder.Entity<ForumMember>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Age)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(5);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Passward).IsRequired();

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Points).HasMaxLength(10);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ForumMember)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_ForumMember_Role");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EcpayOrderNumber)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PayDate).HasColumnType("datetime");

                entity.Property(e => e.Payment).HasMaxLength(10);

                entity.Property(e => e.PurchaserEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PurchaserName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PurchaserPhone).HasMaxLength(50);

                entity.Property(e => e.Road)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_AspNetUsers1");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Product");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.Property(e => e.PostId).ValueGeneratedNever();

                entity.Property(e => e.Context)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posts_ForumMember");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasMaxLength(50);

                entity.Property(e => e.Language).HasMaxLength(50);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ProductImgId).HasMaxLength(50);

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.Publisher).HasMaxLength(50);

                entity.Property(e => e.Specification).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductImgs>(entity =>
            {
                entity.HasKey(e => e.ProductImgId);

                entity.Property(e => e.ImgLink)
                    .IsRequired()
                    .HasColumnName("imgLink");
            });

            modelBuilder.Entity<ProductTags>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductTags_Product");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ProductTags)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_ProductTags_Tags");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.Property(e => e.TagId).ValueGeneratedNever();

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Thread>(entity =>
            {
                entity.Property(e => e.ThreadId).ValueGeneratedNever();

                entity.Property(e => e.Context)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Img).HasMaxLength(50);

                entity.HasOne(d => d.Foutm)
                    .WithMany(p => p.Thread)
                    .HasForeignKey(d => d.FoutmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Thread_Forum");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Thread)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Thread_ForumMember");
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.HasKey(e => e.ListId);

                entity.Property(e => e.ListId).ValueGeneratedNever();

                entity.Property(e => e.Datetime).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.WishList)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WishList_Product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WishList)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WishList_AspNetUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
