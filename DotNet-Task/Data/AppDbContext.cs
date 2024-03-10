using DotNet_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Task.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Product>().HasKey(c => c.ProductId);
            modelBuilder.Entity<Image>().HasKey(c => c.ImageId);

            modelBuilder.Entity<Product>()
           .HasOne(p => p.Category)
           .WithMany(c => c.Products)
           .HasForeignKey(p => p.CategoryID);

            modelBuilder.Entity<Product>()
        .HasMany(p => p.images)
        .WithOne(i => i.Product)
        .HasForeignKey(i => i.ProductId);

        }
    }
}
