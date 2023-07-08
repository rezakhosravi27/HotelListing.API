using HotelListing.API.Data;
using HotelListing.API.Dto.Auth;
using HotelListing.API.Dto.User;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto); 
        Task<AuthResponseDto> Login(LoginDto loginDto); 
    }
}
