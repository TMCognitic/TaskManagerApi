using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagerApi.Dtos.Utilisateurs;

namespace TaskManagerApi.Infrastructure
{
    public class TokenService : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContext;

        public TokenService(IConfiguration configuration, IHttpContextAccessor httpContext)
        {
            _configuration = configuration;
            _httpContext = httpContext;
        }

        public UtilisateurDto? Utilisateur
        {
            get
            {
                string? token = ExtractToken();

                if (token is null)
                {
                    return null;
                }

                return ExtractDataFromToken(token);
            }
        }

        public void ApplyToken(UtilisateurDto user)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.Default.GetBytes("peALmr3S@BuYyKc-^E_enw*KVTFfU8D+7XQaTL2S"));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Issuer"],
                audience: _configuration["Audience"],
                claims: [
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Nom", user.Nom),
                    new Claim("Prenom", user.Prenom),
                    new Claim("Email", user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())],
                signingCredentials: creds);

            user.Token = new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string? ExtractToken()
        {
            const string prefix = "Bearer ";
            HttpContext? httpContext = _httpContext.HttpContext;
            if (httpContext is null)
            {
                throw new InvalidOperationException();
            }

            StringValues autorisations = httpContext.Request.Headers["Authorization"];

            string? token = autorisations.SingleOrDefault(a => a.StartsWith(prefix));

            if (token is null)
                return null;

            return token.Replace(prefix, "");
        }

        private UtilisateurDto ExtractDataFromToken(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken? jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken is null)
                throw new InvalidOperationException("Invalid token.");
                        
            JwtPayload payload = jsonToken.Payload;

            return new UtilisateurDto()
            {
                Id = int.Parse((string)payload["Id"]),
                Nom = (string)payload["Nom"],
                Prenom = (string)payload["Prenom"],
                Email = (string)payload["Email"],
                Token = token,
            };
        }
    }
}
