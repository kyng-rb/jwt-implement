using System.Text;
using jwt_implement.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using jwt_implement.Models.Configuration;
using Microsoft.Extensions.Options;

namespace jwt_implement.Auth
{
    public class CreateToken : ICreateToken
    {
        private readonly SecurityOptions _securityOptions;

        public CreateToken(IOptions<SecurityOptions> securityOptions)
        {
            _securityOptions = securityOptions.Value;
        }

        string ICreateToken.Create(User user)
        {
            var key = Encoding.ASCII.GetBytes(_securityOptions.Key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(_securityOptions.ExpireTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _securityOptions.Audience,
                Issuer = _securityOptions.Issuer
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
