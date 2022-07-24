
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Data.Requests;
using UsuarioAPI.Services;

namespace UsuarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LogaUsuario(LoginRequest request)
        {
            Result resultado = _loginService.LogaUsuario(request);
            if(resultado.IsFailed) return Unauthorized(resultado.Errors); // Se o usuario não for autorizado
            return Ok(resultado.Successes);
        }
        
    }
}