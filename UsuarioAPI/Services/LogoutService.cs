using System;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace UsuarioAPI.Services
{
    public class LogoutService
    {
         private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result DeslogaUsuario()
        {
           var resultadoIdeintity = _signInManager.SignOutAsync();
           if(resultadoIdeintity.IsCompletedSuccessfully) return Result.Ok();
           return Result.Fail("Logout falhou!");
        }
    }
}