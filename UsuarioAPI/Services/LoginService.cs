using System;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioAPI.Data.Requests;
using UsuarioAPI.Models;

namespace UsuarioAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, false, false);
                if(resultadoIdentity.Result.Succeeded)
                {
                    var identityUser = _signInManager
                    .UserManager
                    .Users
                    .FirstOrDefault(usuario =>
                    usuario.NormalizedUserName == request.UserName.ToUpper());
                    Token token = _tokenService.CreateToken(identityUser);
                    return Result.Ok().WithSuccess(token.Value); // Retorna  sucesso com o valor do token
                } 
                return Result.Fail("Login falhou!");
        }

        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            //Token de redifinição
            IdentityUser<int> identityUser = _signInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.NormalizedEmail == request.Email.ToUpper());

            if(identityUser != null)
            {
                string tokenRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(tokenRecuperacao);
            }

            return Result.Fail("Falha ao solicitar redifinição de senha");
        }
    }
}