using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Dto.Auth;
using HotelListing.API.Dto.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelListing.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<APIUser> _userManager;
        private readonly IConfiguration _Configuration;

        public AuthManager(IMapper mapper, UserManager<APIUser> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            bool isvalid = await _userManager.CheckPasswordAsync(user, loginDto.Password);

           if(user == null || isvalid == false) {
                return null;
            }

            var token = GenerateToken(user);

            return new AuthResponseDto
            {
                UserId = user.Id,
                Token = token
            }
        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
        {
            var user = _mapper.Map<APIUser>(userDto);
            user.UserName = userDto.Email;

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result.Errors; 
        }

        private async Task<string> GenerateToken(APIUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JwtSettings: Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
            }
            .Union(roleClaims).Union(userClaims);

            var token = new JwtSecurityToken(
                    issuer: _Configuration["Jwt: Issuer"], 
                    audience: _Configuration["Jwt: Audience"], 
                    claims: claims, 
                    expires: DateTime.Now.AddMinutes(Convert.ToInt32(_Configuration["Jwt: DurationInMinutes"])),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token); 


        }
    }
}
