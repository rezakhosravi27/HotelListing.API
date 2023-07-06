using HotelListing.API.Dto.hotel;
using HotelListing.API.Models;

namespace HotelListing.API.Dto.countries
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<HotelDto> Hotels { get; set; }
    }
}
