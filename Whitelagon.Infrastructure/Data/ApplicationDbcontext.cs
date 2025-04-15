using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whitelagon.admin.Entities;

namespace Whitelagon.Infrastructure.Data
{
    public class ApplicationDbcontext : IdentityDbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<Villanumber> Villanumbers { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<AppIdentitiy> AppIdentitiys { get; set; }
        public DbContextOptions<ApplicationDbcontext> Options { get; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Villa>().HasData(new Villa
            {
                Id = 1,
                Name = "Royal Villa",
                Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                ImageUrl = "https://placehold.co/600x400",
                Occupancy = 4,
                Price = 200,
                Sqft = 550,
            },
new Villa
{
    Id = 2,
    Name = "Premium Pool Villa",
    Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
    ImageUrl = "https://placehold.co/600x401",
    Occupancy = 4,
    Price = 300,
    Sqft = 550,
},
new Villa
{
    Id = 3,
    Name = "Luxury Pool Villa",
    Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
    ImageUrl = "https://placehold.co/600x402",
    Occupancy = 4,
    Price = 400,
    Sqft = 750,

});

            modelBuilder.Entity<Villanumber>().HasData(
             new Villanumber
             {
                 Villa_Number = 101,
                 Villa_Id = 1,
             },
             new Villanumber
             {
                 Villa_Number = 103,
                 Villa_Id = 1,
             },
             new Villanumber
             {
                 Villa_Number = 104,
                 Villa_Id = 1,
             },
             new Villanumber
             {
                 Villa_Number = 105,
                 Villa_Id = 1,
             },
             new Villanumber
             {
                 Villa_Number = 201,
                 Villa_Id = 2,
             },
             new Villanumber
             {
                 Villa_Number = 202,
                 Villa_Id = 2,
             },
             new Villanumber
             {
                 Villa_Number = 203,
                 Villa_Id = 2,
             }

                );


            modelBuilder.Entity<Amenity>().HasData(new Amenity
            {
                    Id = 1,
                    Name = "Swimming Pool",
                    Description = "A beautiful swimming pool with a view.",
                    VillaId = 1
                },
                new Amenity
                {
                    Id = 2,
                    Name = "Gym",
                    Description = "A well-equipped gym for fitness enthusiasts.",
                    VillaId = 2
                }
               , new Amenity{
                Id = 7,
                  VillaId = 2,
                  Name = "Private Balcony"
              }, 
                 new Amenity
            {
                Id = 8,
                VillaId = 2,
                Name = "king bed or 2 double beds"
            },
                 new Amenity
                 {
                  Id = 9,
                  VillaId = 3,
                  Name = "Private Pool"
              },
                 new Amenity
                 {
                  Id = 10,
                  VillaId = 3,
                  Name = "Jacuzzi"
              }, new Amenity
              {
                  Id = 11,
                  VillaId = 3,
                  Name = "Private Balcony"
              }
            );

        }
    }
}
