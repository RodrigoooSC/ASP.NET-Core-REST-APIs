using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using UsuarioAPI.Models;

namespace UsuarioAPI.Services
{
    public class TokenService // Token se acesso para o usuario
    {        
       public Token CreateToken(IdentityUser<int> usuario)
       {
            Claim[] direitosUsuario = new Claim[]
            {
                new Claim("usename", usuario.UserName),
                new Claim("id", usuario.Id.ToString())
            };

            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("0asdjas09djsa")
            );
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims : direitosUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);
       }
        
    }
}