using linkbase_api.Models;
using Microsoft.EntityFrameworkCore;

namespace linkbase_api.Context
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

      modelBuilder.Entity<Folder>()
        .HasOne(f => f.User)
        .WithMany(u => u.Folders)
        .HasForeignKey(f => f.UserId);

      modelBuilder.Entity<Link>()
        .HasOne(l => l.Folder)
        .WithMany(f => f.Links)
        .HasForeignKey(l => l.FolderId);
    }
  }
}
