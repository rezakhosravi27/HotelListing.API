using HotelListing.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
        }
    }
}
