using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id=1,
                    Name="Egypt",
                    ShortName="EG"
                }
                ,
                 new Country
                 {
                     Id = 2,
                     Name = "Bahamas",
                     ShortName = "BS"
                 }
                 , 
                 new Country
                 {
                     Id = 3,
                     Name = "Cayman Island",
                     ShortName = "CI"
                 }

                );

            builder.Entity<Hotel>().HasData(  
             new Hotel
             {
                 Id = 1,
                 Name = "Marriott Egypt",
                 Address = "EG",
                 CountryId= 1,
                 Rating = 4.5
             }
             ,
              new Hotel
              {
                  Id = 2,
                  Name = "Grand Palldium",
                  Address = "Nassua",
                  CountryId = 2,
                  Rating = 3
              }
              ,
              new Hotel
              {
                  Id = 3,
                  Name = "Comfort Suites",
                  Address = "George Twon",
                  CountryId = 3,
                  Rating = 4
              }

             );
        }


    }
}
