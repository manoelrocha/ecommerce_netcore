using Microsoft.IdentityModel.Tokens;
using ProjetoAPI02.Security.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoAPI02.Security.Services
{
    public class TokenService
    {
        //atributo
        private AppSettings appSettings;

        //construtor para inicialização..
        public TokenService(AppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        /// <summary>
        /// Método para gerar o TOKEN de autenticação do usuário
        /// </summary>
        /// <param name="user">Nome do usuário autenticado na aplicação</param>
        /// <returns>TOKEN JWT gerado</returns>
        public string GenerateToken(string user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user) }),
                Expires = DateTime.Now.AddDays(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
