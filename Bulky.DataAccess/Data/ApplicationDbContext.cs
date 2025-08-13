using Bulky.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) :base(options)
        {
            
        }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Product>Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                
                new Category {Id = 1, DisplayOrder = 1 , Name ="Actions"},
                new Category { Id=2,DisplayOrder = 2 , Name ="History"},
                new Category { Id=3,DisplayOrder = 3 , Name ="SciFi" }
                );
            modelBuilder.Entity<Product>().HasData(
      new Product
      {
          Id = 1,
          Title = "Coffee Machine",
          Author = "Amr ELdeeb",
          ISBN = "7332",
          Description = "No Now Pro",
          ListPrice = 80,
          Price = 75,
          Price50 = 70,
          Price100 = 65
      },
new Product
{
    Id = 2,
    Title = "Electric Kettle",
    Author = "Sara Khaled",
    ISBN = "4821",
    Description = "Fast boil 1.7L",
    ListPrice = 50,
    Price = 45,
    Price50 = 40,
    Price100 = 35
},
new Product
{
    Id = 3,
    Title = "Blender",
    Author = "Mohamed Ali",
    ISBN = "9154",
    Description = "600W with glass jar",
    ListPrice = 120,
    Price = 110,
    Price50 = 100,
    Price100 = 90
},
new Product
{
    Id = 4,
    Title = "Microwave Oven",
    Author = "Omar Fathy",
    ISBN = "6723",
    Description = "20L compact microwave",
    ListPrice = 200,
    Price = 190,
    Price50 = 180,
    Price100 = 170
},
new Product
{
    Id = 5,
    Title = "Air Fryer",
    Author = "Nour Hassan",
    ISBN = "8439",
    Description = "3.5L oil-free cooking",
    ListPrice = 150,
    Price = 140,
    Price50 = 130,
    Price100 = 120
},
new Product
{
    Id = 6,
    Title = "Espresso Machine",
    Author = "Amr ELdeeb",
    ISBN = "2948",
    Description = "15 bar pump pressure",
    ListPrice = 250,
    Price = 240,
    Price50 = 230,
    Price100 = 220
},
new Product
{
    Id = 7,
    Title = "Toaster",
    Author = "Ali Ahmed",
    ISBN = "3572",
    Description = "2-slice stainless steel",
    ListPrice = 40,
    Price = 38,
    Price50 = 35,
    Price100 = 32
},
new Product
{
    Id = 8,
    Title = "Rice Cooker",
    Author = "Huda Samir",
    ISBN = "7810",
    Description = "1.8L automatic keep warm",
    ListPrice = 90,
    Price = 85,
    Price50 = 80,
    Price100 = 75
},
new Product
{
    Id = 9,
    Title = "Stand Mixer",
    Author = "Khaled Mansour",
    ISBN = "5264",
    Description = "5L bowl, 6-speed settings",
    ListPrice = 300,
    Price = 290,
    Price50 = 280,
    Price100 = 270
},
new Product
{
    Id = 10,
    Title = "Hand Blender",
    Author = "Aya Adel",
    ISBN = "6491",
    Description = "Variable speed control",
    ListPrice = 60,
    Price = 55,
    Price50 = 50,
    Price100 = 45
}


);


        }



    }
}
