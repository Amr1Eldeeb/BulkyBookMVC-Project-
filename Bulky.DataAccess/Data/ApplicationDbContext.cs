using Bulky.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options)
        {
            
        }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Product>Products { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>().HasData(
      new Category { Id = 1, Name = "Electronics" },
      new Category { Id = 2, Name = "Books" },
      new Category { Id = 3, Name = "Furniture" }
  );
            modelBuilder.Entity<Product>().HasData(
    new Product { Id = 1, Title = "Cold Brew Coffee Maker", Author = "Coffee Experts Co.", ISBN = "CM-1011", Description = "Specialized machine for cold brew coffee", ListPrice = 150, Price = 140, Price50 = 130, Price100 = 120, CategoryId = 1,ImageUrl="" },
    new Product { Id = 2, Title = "French Press Coffee Set", Author = "Coffee Experts Co.", ISBN = "CM-1012", Description = "Classic French press with stainless steel plunger", ListPrice = 80, Price = 75, Price50 = 70, Price100 = 65, CategoryId = 2, ImageUrl = "" },
    new Product { Id = 3, Title = "Smart Grinder Coffee Machine", Author = "Coffee Experts Co.", ISBN = "CM-1013", Description = "Coffee machine with built-in smart grinder", ListPrice = 500, Price = 480, Price50 = 460, Price100 = 440, CategoryId = 3, ImageUrl = "" },
    new Product { Id = 4, Title = "Portable Espresso Maker", Author = "Coffee Experts Co.", ISBN = "CM-1014", Description = "Handheld espresso machine for coffee on the go", ListPrice = 90, Price = 85, Price50 = 80, Price100 = 75, CategoryId = 1, ImageUrl = "" },
    new Product { Id = 5, Title = "Barista Training Coffee Machine", Author = "Coffee Experts Co.", ISBN = "CM-1015", Description = "Machine designed for barista practice and training", ListPrice = 650, Price = 620, Price50 = 600, Price100 = 580, CategoryId = 2, ImageUrl = "" }
);


            


        }



    }
}
