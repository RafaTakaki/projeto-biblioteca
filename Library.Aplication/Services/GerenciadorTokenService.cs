using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Library.Domain.Entities;
using Library.Domain.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Library.Aplication.Services
{
    public class GerenciadorTokenService : IGerenciadorTokenService
    {
        private readonly IConfiguration _configuration;

        public GerenciadorTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<string> GerarToken(Usuario usuario)
        {
            try
            {
                var jwtSettings = _configuration.GetSection("JwtSettings");
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(jwtSettings["SecretKey"] ?? string.Empty));

                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.TipoUsuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

                var tempoDeExpiracaoInMinutes = int.Parse(jwtSettings["ExpirationTimeInMinutes"] ?? "30");


                var token = new JwtSecurityToken(
                    issuer: jwtSettings["Issuer"],
                    audience: jwtSettings["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(tempoDeExpiracaoInMinutes),
                    signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256));


                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gerar o token", ex);
            }
        }


        public async Task<string> BuscarGuidToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub").Value;
                var idString = userIdClaim.Replace("id: ", "").Trim();

                return idString;

            }
            catch (Exception ex)
            {
                return null; // Retorna null se o token for inválido ou ocorrer um erro);
            }
        }


    }
}