using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Science Fiction", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Example Description for the selected book",
                    ISBN = "PWSC111111101",
                    ListPrice = 99,
                    Price = 90,
                    Price5 = 85,
                    Price10 = 80,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Example Description for the selected book",
                    ISBN = "LK55111111101",
                    ListPrice = 40,
                    Price = 30,
                    Price5 = 25,
                    Price10 = 20,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Example Description for the selected book",
                    ISBN = "ZZZZ1111111101",
                    ListPrice = 55,
                    Price = 50,
                    Price5 = 40,
                    Price10 = 35,
                    CategoryId = 3,
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Example Description for the selected book",
                    ISBN = "WSJW1111111101",
                    ListPrice = 70,
                    Price = 65,
                    Price5 = 60,
                    Price10 = 55,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Example Description for the selected book",
                    ISBN = "S0TJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price5 = 25,
                    Price10 = 20,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phanton",
                    Description = "Example Description for the selected book",
                    ISBN = "F0T01111111101",
                    ListPrice = 25,
                    Price = 23,
                    Price5 = 22,
                    Price10 = 20,
                    CategoryId = 1
                }
                );
        }
    }
}
