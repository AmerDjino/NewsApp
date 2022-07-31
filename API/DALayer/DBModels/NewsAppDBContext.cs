using System;
using System.Collections.Generic;
using API.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DALayer
{
    public partial class NewsAppDBContext : DbContext
    {
        public NewsAppDBContext()
        {
        }

        public NewsAppDBContext(DbContextOptions<NewsAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<ArticleComment> ArticleComments { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Picture> Pictures { get; set; } = null!;
        public virtual DbSet<Priviledge> Priviledges { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=API2121;Database=NewsAppDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.Property(e => e.ArticleId)
                    .ValueGeneratedNever()
                    .HasColumnName("ArticleID");

                entity.Property(e => e.ArticleTitle).HasMaxLength(150);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.IsEdited).HasColumnName("isEdited");

                entity.Property(e => e.IsEditing).HasColumnName("isEditing");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Category_Article_CategoryID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_User_Article_UserID");

                entity.HasMany(d => d.Pictures)
                    .WithMany(p => p.Articles)
                    .UsingEntity<Dictionary<string, object>>(
                        "ArticlePicture",
                        l => l.HasOne<Picture>().WithMany().HasForeignKey("PictureId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Picture_ArticlePicture_PictureID"),
                        r => r.HasOne<Article>().WithMany().HasForeignKey("ArticleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Article_ArticlePicture_ArticleID"),
                        j =>
                        {
                            j.HasKey("ArticleId", "PictureId").HasName("Pk_ArticlePicture_ArticleIDPictureID");

                            j.ToTable("ArticlePicture");

                            j.IndexerProperty<Guid>("ArticleId").HasColumnName("ArticleID");

                            j.IndexerProperty<Guid>("PictureId").HasColumnName("PictureID");
                        });

                entity.HasMany(d => d.Tags)
                    .WithMany(p => p.Articles)
                    .UsingEntity<Dictionary<string, object>>(
                        "ArticleTag",
                        l => l.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Tag_ArticleTag_TagID"),
                        r => r.HasOne<Article>().WithMany().HasForeignKey("ArticleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Article_ArticleTag_ArticleID"),
                        j =>
                        {
                            j.HasKey("ArticleId", "TagId").HasName("Pk_ArticleTag_ArticleIDTagID");

                            j.ToTable("ArticleTag");

                            j.IndexerProperty<Guid>("ArticleId").HasColumnName("ArticleID");

                            j.IndexerProperty<Guid>("TagId").HasColumnName("TagID");
                        });
            });

            modelBuilder.Entity<ArticleComment>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.UserId, e.CommentId })
                    .HasName("Pk_ArticleComment_ArticleIDUserIDCommentID");

                entity.ToTable("ArticleComment");

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleComments)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Article_ArticleComment_ArticleID");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.ArticleComments)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Comment_ArticleComment_CommentID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ArticleComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_User_ArticleComment_UserID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId)
                    .ValueGeneratedNever()
                    .HasColumnName("CommentID");

                entity.Property(e => e.ParentCommentId).HasColumnName("ParentCommentID");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.ToTable("Picture");

                entity.Property(e => e.PictureId)
                    .ValueGeneratedNever()
                    .HasColumnName("PictureID");

                entity.Property(e => e.PictureDescription).HasMaxLength(300);

                entity.Property(e => e.PictureUrl).HasColumnName("PictureURL");
            });

            modelBuilder.Entity<Priviledge>(entity =>
            {
                entity.ToTable("Priviledge");

                entity.Property(e => e.PriviledgeId)
                    .ValueGeneratedNever()
                    .HasColumnName("PriviledgeID");

                entity.Property(e => e.PriviledgeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleDesription).HasMaxLength(50);

                entity.HasMany(d => d.Priviledges)
                    .WithMany(p => p.Roles)
                    .UsingEntity<Dictionary<string, object>>(
                        "RolePriviledge",
                        l => l.HasOne<Priviledge>().WithMany().HasForeignKey("PriviledgeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Priviledge_RolePriviledge_PriviledgeID"),
                        r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Role_RolePriviledge_RoleID"),
                        j =>
                        {
                            j.HasKey("RoleId", "PriviledgeId").HasName("Pk_RolePriviledge_RoleIDPriviledgeID");

                            j.ToTable("RolePriviledge");

                            j.IndexerProperty<Guid>("RoleId").HasColumnName("RoleID");

                            j.IndexerProperty<Guid>("PriviledgeId").HasColumnName("PriviledgeID");
                        });
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.TagId)
                    .ValueGeneratedNever()
                    .HasColumnName("TagID");

                entity.Property(e => e.TagName).HasMaxLength(25);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(1024);

                entity.Property(e => e.PasswordSalt).HasMaxLength(1024);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_Role_UserRole_RoleID"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Fk_User_UserRole_UserID"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("Pk_UserRole_UserIDRoleID");

                            j.ToTable("UserRole");

                            j.IndexerProperty<Guid>("UserId").HasColumnName("UserID");

                            j.IndexerProperty<Guid>("RoleId").HasColumnName("RoleID");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
