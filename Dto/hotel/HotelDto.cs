using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HotelListing.API.Dto.Hotel;

namespace HotelListing.API.Dto.Hotels
{
    public class HotelDto: BaseHotelDto
    {
        public int Id { get; set; }
    }
}