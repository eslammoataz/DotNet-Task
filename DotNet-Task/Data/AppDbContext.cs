using DotNet_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet_Task.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Defining the Ids
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<SubCategory>().HasKey(s => s.SubCategoryId);
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);

            //Defining the relationships
            modelBuilder.Entity<Category>()
                .HasMany(c => c.SubCategories)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<SubCategory>().HasMany(s => s.Products)
                .WithOne(p => p.SubCategory)
                .HasForeignKey(p => p.SubCategoryId);


        }
    }
}
