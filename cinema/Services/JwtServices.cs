using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using cinema.Abstractions;
using cinema.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace cinema.Services
{
    public class JwtServices : IJwtServices
    {
        private readonly AuthOptions _authOptions;

        public JwtServices(AuthOptions authOptions)
        {
            _authOptions = authOptions;
        }
        public string Generate(string chat_id)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, chat_id) };

            var jwt = new JwtSecurityToken(
                issuer: _authOptions.ISSUER,
                audience: _authOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                signingCredentials: new SigningCredentials(_authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
