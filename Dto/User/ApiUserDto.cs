using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Dto.User
{
    public class ApiUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "stirng length must between 15 and 5", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
