using Microsoft.Build.Framework;

namespace HotelListing.API.Dto.countries
{
    public class CreateCountry
    {
        [Required]
        public string Name  { get; set; }
        public string ShortName { get; set; }
    }
}
