using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shop.Data.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Services
{
    public interface IJwtTokenService
    {
        string CreateToken(AppUser user);
    }
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public JwtTokenService(IConfiguration configuration,
            UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public string CreateToken(AppUser user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            List<Claim> claims = new List<Claim>()
            {
                new Claim("name", user.UserName)//,
                //new Claim("image", user.Photo)
            };
            if (roles.Any())
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim("roles", role));
                }
            }
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<String>("JwtKey")));
            var signinCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                signingCredentials: signinCredentials,
                expires: DateTime.Now.AddDays(1000),
                claims: claims
            );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}