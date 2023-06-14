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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("DataSource=E:\\GitHub Repozytoria\\GameStore\\GameStore\\Data\\GameStoreDB.db ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            });

            modelBuilder.Entity<Game>(entity =>
            {
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
                entity.Property(e => e.LibraryId).HasColumnName("LibraryID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Libraries)
                    .HasForeignKey(d => d.UserId);
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
                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
