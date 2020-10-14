using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using XforumTest.DataTable;

namespace XforumTest.Context
{
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
        {
        }

        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<ForumMembers> ForumMembers { get; set; }
        public virtual DbSet<ForumRoles> ForumRoles { get; set; }
        public virtual DbSet<Forums> Forums { get; set; }
        public virtual DbSet<MemberTitle> MemberTitle { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductImgs> ProductImgs { get; set; }
        public virtual DbSet<ProductTags> ProductTags { get; set; }
        public virtual DbSet<ReposiveMessages> ReposiveMessages { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Titles> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=azurewebtest.database.windows.net,1433;Database=MyDB;User=azurewebtest;Password=yphrT8Cn;");
            }
        }

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

            modelBuilder.Entity<ForumMembers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_ForumMember");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.ImgLink).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Points).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ForumMembers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_ForumMembers_ForumRoles");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.ForumMembers)
                    .HasForeignKey(d => d.TitleId)
                    .HasConstraintName("FK_ForumMembers_Titles");
            });

            modelBuilder.Entity<ForumRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_ForumRole");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Forums>(entity =>
            {
                entity.HasKey(e => e.ForumId)
                    .HasName("PK_Forum");

                entity.Property(e => e.ForumId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.ForumName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Img).HasMaxLength(50);

                entity.Property(e => e.RouteName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Moderator)
                    .WithMany(p => p.Forums)
                    .HasForeignKey(d => d.ModeratorId)
                    .HasConstraintName("FK_Forums_ForumMembers");
            });

            modelBuilder.Entity<MemberTitle>(entity =>
            {
                entity.HasOne(d => d.HasTitle)
                    .WithMany(p => p.MemberTitle)
                    .HasForeignKey(d => d.HasTitleId)
                    .HasConstraintName("FK_MemberTitle_Titles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MemberTitle)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_MemberTitle_ForumMembers");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.Property(e => e.PostId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Img)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Forum)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.ForumId)
                    .HasConstraintName("FK_Posts_Forums");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Posts_ForumMembers");
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

            modelBuilder.Entity<ReposiveMessages>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.MessageId).ValueGeneratedNever();

                entity.Property(e => e.Context).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.ReposiveMessages)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_ReposiveMessages_Posts");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.Property(e => e.TagId).ValueGeneratedNever();

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Titles>(entity =>
            {
                entity.HasKey(e => e.TitleId);

                entity.Property(e => e.TitleId).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TitleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
