using System;
using System.Threading.Tasks;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioAPI.Data.Requests;

namespace UsuarioAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager
                .PasswordSignInAsync(request.UserName, request.Password, false, false);
                if(resultadoIdentity.Result.Succeeded) return Result.Ok();
                return Result.Fail("Login falhou!");
        }
    }
}