using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace cinema.Helpers
{
    public class AuthOptions
    {
        public string ISSUER { get; set; } = null!;
        public string AUDIENCE { get; set; } = null!;
        public string KEY { get; set; } = null!;
        // возвращает ключ безопасности, который применяется для генерации токена
        public SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
