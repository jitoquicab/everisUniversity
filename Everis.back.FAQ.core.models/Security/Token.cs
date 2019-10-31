using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Everis.back.FAQ.core.models.Peticiones.v1.Usuarios.Response;

namespace Everis.back.FAQ.core.models.Security
{
    public class Token
    {
        public string _token { get; set; }
        public Token(string token)
        {
            _token = token;
        }
        public string BuildToken(ResponseUsuario user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_token));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var oClaims = new List<Claim>
            {
                new Claim("AppID","ECP_App"),
                new Claim("EmailCorporativo", user.nickname),
                new Claim("idUsuario", user.idUsuario.ToString()),
            };

            var token = new JwtSecurityToken("http://localhost:63939/",
              _token,
              expires: DateTime.Now.AddHours(10),
              signingCredentials: creds,
                claims: oClaims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
