using HotelListing.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
