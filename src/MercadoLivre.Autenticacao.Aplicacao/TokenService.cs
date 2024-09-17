using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using MercadoLivre.Autenticacao.Dominio;
using Microsoft.Extensions.Configuration;

namespace MercadoLivre.Autenticacao.Aplicacao
{
    public class TokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Generate(UsuarioLogin usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var issuerKey = _configuration.GetSection("jwt-key").Value;

            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerKey)), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddMinutes(5),
                Subject = GenerateClaims(usuario)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private ClaimsIdentity GenerateClaims(UsuarioLogin usuario)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim("id", usuario.Id.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Name, usuario.Login));
            ci.AddClaim(new Claim(ClaimTypes.Email, usuario.Login));
            return ci;
        }
    }
}
