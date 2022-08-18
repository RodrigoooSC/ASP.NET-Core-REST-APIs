using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsuarioAPI.Models;

namespace UsuarioAPI.Services
{
    public class LogoutService
    {
         private SignInManager<CustomIdentityUser> _signInManager;

        public LogoutService(SignInManager<CustomIdentityUser> signInManager)
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