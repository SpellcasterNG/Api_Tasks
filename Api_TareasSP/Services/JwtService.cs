using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TareasSP_DB;

namespace Api_TareasSP.Services
{
    public interface IJwtService
    {
        string BuildToken(User user);
    }
    public class JwtService : IJwtService
    {
        private readonly SigningCredentials _credentials;
        private readonly int _expiresDays;

        public JwtService(IConfiguration configuration)
        {
            _expiresDays = configuration.GetValue<int>("Jwt:ExpiresDays");

            var key = configuration["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            _credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }

        public string BuildToken(User user)
        {
            var claims = new[]
            {
                new Claim("id", user.Id_User.ToString()),
                new Claim("email", user.Email)
            };

            var expires = DateTime.UtcNow.AddDays(_expiresDays);
            var tokenDescriptor = new JwtSecurityToken(claims: claims, expires: expires, signingCredentials: _credentials);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return token;
        }
    }
}
