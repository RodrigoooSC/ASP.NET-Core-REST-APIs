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
        private SignInManager<CustomIdentityUser> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<CustomIdentityUser> signInManager, TokenService tokenService)
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
                    Token token = _tokenService.CreateToken(identityUser, _signInManager
                    .UserManager
                    .GetRolesAsync(identityUser).Result.FirstOrDefault());
                    return Result.Ok().WithSuccess(token.Value); // Retorna  sucesso com o valor do token
                } 
                return Result.Fail("Login falhou!");
        }       

        public Result SolicitaResetSenhaUsuario(SolicitaResetRequest request)
        {
            //Token de redifinição
            CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);

            if (identityUser != null)
            {
                string tokenRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(tokenRecuperacao);
            }

            return Result.Fail("Falha ao solicitar redifinição de senha");
        }       

        public Result ResetaSenhaUsuario(EfetuaResetRequest request)
        {
            // Redefinição de senha
             CustomIdentityUser identityUser = RecuperaUsuarioPorEmail(request.Email);

            IdentityResult resultadoIdentity = _signInManager
            .UserManager
            .ResetPasswordAsync(identityUser, request.Token, request.Password)
            .Result;
            if(resultadoIdentity.Succeeded) return Result.Ok()
            .WithSuccess("Senha redefinida com sucesso");

            return Result.Fail("Houve um erro na operação");

        }

         private CustomIdentityUser RecuperaUsuarioPorEmail(string email)
        {
            return _signInManager
                        .UserManager
                        .Users
                        .FirstOrDefault(user => user.NormalizedEmail == email.ToUpper());
        }
    }
}