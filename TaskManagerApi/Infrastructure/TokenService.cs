using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using TaskManagerApi.Bll.Entities;

namespace TaskManagerApi.Infrastructure
{
    public class TokenService : ITokenRepository
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.Default.GetBytes("peALmr3S@BuYyKc-^E_enw*KVTFfU8D+7XQaTL2S"));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Issuer"],
                audience: _configuration["Audience"],
                claims: [
                    new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, $"{user.Prenom} {user.Nom}"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    ],
                //expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
