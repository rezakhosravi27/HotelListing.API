using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Dto.User
{
    public class BaseUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Password length must between 15 and 5", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
