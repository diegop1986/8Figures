using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using EightFigures.Contacts.Service.Enum;
using EightFigures.Contacts.Service.Interface;

namespace EightFigures.Contacts.Service.Implementation
{
    public class TokenManagerService: ITokenManagerService
    {
        private readonly ISettings settings;

        public TokenManagerService(ISettings settings) => this.settings = settings;

        public (string, DateTime) GenerateToken(string logIn, int id)
        {
            var key = Encoding.UTF8.GetBytes(settings.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(PayloadProperty.UserRequest.ToString(), logIn),
                    new Claim(PayloadProperty.UserId.ToString(), id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(settings.ExpiryDurationMinutes),
                Issuer = settings.Issuer,
                Audience = settings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (tokenHandler.WriteToken(token), tokenDescriptor.Expires.Value);
        }
    }
}
