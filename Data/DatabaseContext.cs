using HotelListing.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Hotel Tehran",
                    Address = "Marzdaran",
                    Rating = 4,
                    CountryId = 1,

                },
                new Hotel
                {
                    Id = 2,
                    Name = "Hotel Shiraz",
                    Address = "Motahari",
                    Rating = 5,
                    CountryId = 1,
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Hotel Esfahan",
                    Address = "Emam Khomeini",
                    Rating = 4.3,
                    CountryId = 1,
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1, 
                    Name = "Iran",
                    ShortName = "Ir"
                },
                new Country
                {
                    Id = 2,
                    Name = "Unitad States",
                    ShortName = "Us"
                }
            );
        }
    }
}
