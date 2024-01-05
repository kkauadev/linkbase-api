using LinkBaseApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkBaseApi.Persistence.Context
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => new { u.Email }).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => new { u.Username }).IsUnique();

            modelBuilder.Entity<User>().Property(u => u.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<User>().Property(u => u.LastUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<User>().Property(u => u.LastUpdated).ValueGeneratedOnUpdate();

            modelBuilder.Entity<Folder>()
              .HasOne<User>()
              .WithMany(e => e.Folders)
              .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Link>()
              .HasOne<Folder>()
              .WithMany(e => e.Links)
              .HasForeignKey(e => e.FolderId);

            modelBuilder.Entity<Folder>().Property(u => u.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Folder>().Property(u => u.LastUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Folder>().Property(f => f.LastUpdated).ValueGeneratedOnUpdate();

            modelBuilder.Entity<Link>().Property(u => u.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Link>().Property(u => u.LastUpdated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Link>().Property(l => l.LastUpdated).ValueGeneratedOnUpdate();
        }
    }
}
