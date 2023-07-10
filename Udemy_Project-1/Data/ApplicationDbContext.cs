//using ConsumingApiSection.Models;
using Microsoft.EntityFrameworkCore;
using Udemy_Project_1.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Udemy_Project_1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


		public DbSet<LocalUser>LocalUsers
		{ get; set; }
		public DbSet<Villa> Villas1
        { get; set; }
        public DbSet<VillaNumber> VillaNumber
        { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "ahbsdjcnnnnnnnnnnm jxnsjncd xjnjx",
                    imgUrl = "httss jnc",
                    occupancy=4,
                    Rate=100,
                    sqft=100,
                    Amenity="",
                    CreatedTime=DateTime.Now,
                },
                new Villa() 
                {
                Id = 2,
                    Name = "Royal Villa2",
                    Details = "ahbsdjcnnnnnnnnnnm jxnsjncd xjnjx",
                    imgUrl = "httss jnc",
                    occupancy = 4,
                    Rate = 100,
                    sqft = 100,
                    Amenity = "",
                    CreatedTime = DateTime.Now,

                },
                new Villa()

                {
                    Id = 3,
                    Name = "Royal Villa3",
                    Details = "ahbsdjcnnnnnnnnnnm jxnsjncd xjnjx",
                    imgUrl = "httss jnc",
                    occupancy = 4,
                    Rate = 100,
                    sqft = 100,
                    Amenity = "",
                    CreatedTime = DateTime.Now,
                },
                new Villa()

                {
                    Id = 4,
                    Name = "Royal Villa4",
                    Details = "ahbsdjcnnnnnnnnnnm jxnsjncd xjnjx",
                    imgUrl = "httss jnc",
                    occupancy = 4,
                    Rate = 100,
                    sqft = 100,
                    Amenity = "",
                    CreatedTime = DateTime.Now,
                },
                new Villa()

                {
                    Id = 5,
                    Name = "Royal Villa5",
                    Details = "ahbsdjcnnnnnnnnnnm jxnsjncd xjnjx",
                    imgUrl = "httss jnc",
                    occupancy = 4,
                    Rate = 100,
                    sqft = 100,
                    Amenity = "",
                        CreatedTime = DateTime.Now,
                }
                );
        }

    }
}
