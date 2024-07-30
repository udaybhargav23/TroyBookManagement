using Bulky.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Bulky.Models;

namespace Bulky.DataAccess.Data
{
    //inheritance
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //For creating table with name categories
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //Seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //this means keys of identity table are mapped onto onmodelcreating
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category {Id=1, Name="Action", DisplayOrder=1},
                new Category {Id=2, Name="SciFi", DisplayOrder=2},
                new Category {Id=3, Name="Horror", DisplayOrder=3}
            );

            modelBuilder.Entity<Product>().HasData(
                new Product 
                {
                    Id=1, 
                    Title="Fortune of Time", 
                    Description="Present Vitae Sodales libero.", 
                    ISBN="SWD9999001", 
                    Author="Billy spark", 
                    ListPrice=99, 
                    Price=90, 
                    Price50=85, 
                    Price100=80,
                    CategoryId=1,
                    ImageUrl=""
                }
            );
        }
    }
}