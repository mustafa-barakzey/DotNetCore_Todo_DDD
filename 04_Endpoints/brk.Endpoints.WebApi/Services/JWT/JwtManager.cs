using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace brk.Endpoints.WebApi.Services.JWT
{
    public class JwtManager : IJwtManager
    {
        private readonly JwtSetting _jwtSetting;
        public JwtManager(IOptions<JwtSetting> jwtOption)
        {
            _jwtSetting = jwtOption.Value;
        }
        public Token GenerateToken<TID>(TID userId, string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_jwtSetting.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, userName),
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Token { AccessToken = tokenHandler.WriteToken(token) };
        }
    }
}
