using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameStore
{
    public partial class GameStoreDBContext : DbContext
    {
        public GameStoreDBContext()
        {
        }

        public GameStoreDBContext(DbContextOptions<GameStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<GamesInLibrary> GamesInLibraries { get; set; } = null!;
        public virtual DbSet<Library> Libraries { get; set; } = null!;
        public virtual DbSet<Purchase> Purchases { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=Data\\GameStoreDB.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Categories_CategoryID")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasIndex(e => e.Title, "IX_Games_Title")
                    .IsUnique();

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<GamesInLibrary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GamesInLibrary");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.LibraryId).HasColumnName("LibraryID");

                entity.HasOne(d => d.Game)
                    .WithMany()
                    .HasForeignKey(d => d.GameId);

                entity.HasOne(d => d.Library)
                    .WithMany()
                    .HasForeignKey(d => d.LibraryId);
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.HasIndex(e => e.LibraryId, "IX_Libraries_LibraryID")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "IX_Libraries_UserID")
                    .IsUnique();

                entity.Property(e => e.LibraryId).HasColumnName("LibraryID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Library)
                    .HasForeignKey<Library>(d => d.UserId);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.Property(e => e.PurchaseId).HasColumnName("PurchaseID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.GameId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "IX_Users_Username")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
