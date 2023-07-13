using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Dto.User
{
    public class ApiUserDto : BaseUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
